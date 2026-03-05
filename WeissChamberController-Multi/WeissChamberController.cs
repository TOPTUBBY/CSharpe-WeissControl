using System;
using System.Linq;

namespace Form1
{
    /// <summary>
    /// DTO สำหรับคืนค่าจากคำสั่ง ID ($01I)
    /// </summary>
    public class ModelInfo
    {
        public WeissChamberController.ChamberModel Model { get; set; } = WeissChamberController.ChamberModel.UNKNOWN;
        public double SetTemp { get; set; } = 0;
        public double CurTemp { get; set; } = 0;
        public double SetHumi { get; set; } = 0;
        public double CurHumi { get; set; } = 0;
        public bool IsEnabled { get; set; } = false;
        public string RawResponse { get; set; } = string.Empty;
    }

    public class WeissChamberController
    {
        private ITransport _transport;
        private int _chamberAddress = 1;
        private readonly string _eol = "\r";
        private ChamberModel _currentModel = ChamberModel.UNKNOWN;
        private readonly object _commLock = new object();

        public ChamberModel CurrentModel => _currentModel;


        public enum ChamberModel
        {
            UNKNOWN,
            V08_VCS_7080_10,
            V26_C7_1000_E,
            W27_ESS_C_1000_70_5,
            W28_ESS_C_1300_70_10,
            W29_ESS_T_1700_70_8
        }

        public WeissChamberController(ITransport transport = null)
        {
            _transport = transport;
        }

        public void SetTransport(ITransport transport)
        {
            try
            {
                _transport?.Disconnect();
                _transport?.Dispose();
            }
            catch { }
            _transport = transport;
        }

        public bool InitializeConnection()
        {
            if (_transport == null) return false;
            return _transport.Connect();
        }

        public void Disconnect()
        {
            try
            {
                _transport?.Disconnect();
                _transport?.Dispose();
            }
            catch { }
            _transport = null;
        }

        /// <summary>
        /// เก็บไว้เพื่อความเข้ากันกับโค้ดเดิม (ตรวจ model โดยส่ง $01I)
        /// </summary>
        public ChamberModel CheckChamberModel()
        {
            if (_transport == null || !_transport.IsOpen) return ChamberModel.UNKNOWN;

            string idnCommand = string.Format("$" + "{0:D2}I", _chamberAddress);
            string response = SendCommand(idnCommand);
            if (response == "TIMEOUT" || response.StartsWith("COMM_ERROR"))
            {
                _currentModel = ChamberModel.UNKNOWN;
                return _currentModel;
            }

            string cleanResponse = response.Trim();
            string[] tokens = cleanResponse.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int valueCount = tokens.Length;

            if (valueCount >= 7)
            {
                double tempValue;
                if (tokens.Length >= 7 && double.TryParse(tokens[0], out tempValue))
                {
                    if (tokens[6].StartsWith("0015"))
                        _currentModel = ChamberModel.V08_VCS_7080_10;
                    else
                        _currentModel = ChamberModel.W28_ESS_C_1300_70_10;
                }
            }
            else if (valueCount >= 5)
            {
                double rateValue;
                if (tokens.Length >= 4 && double.TryParse(tokens[2], out rateValue) && double.TryParse(tokens[3], out rateValue))
                {
                    if (tokens[2].StartsWith("0000") && tokens[3].StartsWith("0000"))
                    {
                        if (tokens.Length > 4 && tokens[4].Length >= 3)
                        {
                            // token 5 (tokens[5]) อักขระที่ 3 (index 3) เป็น '1'
                            if (tokens[5][3] == '1')
                                _currentModel = ChamberModel.V26_C7_1000_E;
                            else
                                _currentModel = ChamberModel.W27_ESS_C_1000_70_5; // As per user request: if 0000.0 0000.0 and token 5 digit 3 is not '1'
                        }
                        else
                        {
                            _currentModel = ChamberModel.V26_C7_1000_E;
                        }
                    }
                    else
                    {
                        _currentModel = ChamberModel.W29_ESS_T_1700_70_8;
                    }
                }
            }
            else
            {
                _currentModel = ChamberModel.UNKNOWN;
            }

            return _currentModel;
        }

        /// <summary>
        /// ใหม่: ส่ง $01I ครั้งเดียว แล้วพยายาม parse model + set/actual + enabled state
        /// คืนค่าเป็น bool (true = ได้ response และ parse สำเร็จหรือบางส่วน) และผลผ่าน out ModelInfo
        /// </summary>
        public bool TryGetModelAndParams(out ModelInfo info)
        {
            info = new ModelInfo();

            if (_transport == null || !_transport.IsOpen)
                return false;

            string idnCommand = string.Format("$" + "{0:D2}I", _chamberAddress);
            string response = SendCommand(idnCommand);
            info.RawResponse = response ?? string.Empty;

            if (string.IsNullOrEmpty(response) || response == "TIMEOUT" || response.StartsWith("COMM_ERROR"))
            {
                _currentModel = ChamberModel.UNKNOWN;
                info.Model = ChamberModel.UNKNOWN;
                return false;
            }

            string cleanResponse = response.Trim();
            string[] tokens = cleanResponse.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int valueCount = tokens.Length;

            ChamberModel detected = ChamberModel.UNKNOWN;

            if (valueCount >= 7)
            {
                double tmp;
                if (tokens.Length >= 7 && double.TryParse(tokens[0], out tmp))
                {
                    if (tokens[6].StartsWith("0015"))
                        detected = ChamberModel.V08_VCS_7080_10;
                    else
                        detected = ChamberModel.W28_ESS_C_1300_70_10;
                }
            }
            else if (valueCount >= 5)
            {
                double tmp;
                if (tokens.Length >= 4 && double.TryParse(tokens[2], out tmp) && double.TryParse(tokens[3], out tmp))
                {
                    if (tokens[2].StartsWith("0000") && tokens[3].StartsWith("0000"))
                    {
                        // *** เพิ่มเงื่อนไขเพื่อแยก V26 และ W27 ที่นี่ ***
                        // ตรวจสอบว่ามี token 5 (index 4) และยาวพอหรือไม่
                        if (tokens.Length > 4 && tokens[4].Length >= 3)
                        {
                            // token 5 (tokens[4]) อักขระที่ 3 (index 2) เป็น '1'
                            if (tokens[4][2] == '1')
                                detected = ChamberModel.V26_C7_1000_E;
                            else
                                detected = ChamberModel.W27_ESS_C_1000_70_5; // As per user request: if 0000.0 0000.0 and token 5 digit 3 is not '1'
                        }
                        else
                        {
                            // Fallback
                            detected = ChamberModel.V26_C7_1000_E;
                        }
                    }
                    else
                    {
                        detected = ChamberModel.W29_ESS_T_1700_70_8;
                    }
                }
            }
            else
            {
                detected = ChamberModel.UNKNOWN;
            }

            _currentModel = detected;
            info.Model = detected;

            // Try parse numeric values if present
            try
            {
                if (tokens.Length >= 4)
                {
                    double.TryParse(tokens[0], out double setT);
                    double.TryParse(tokens[1], out double curT);
                    double.TryParse(tokens[2], out double setH);
                    double.TryParse(tokens[3], out double curH);

                    info.SetTemp = setT;
                    info.CurTemp = curT;
                    info.SetHumi = setH;
                    info.CurHumi = curH;
                }

                if (tokens.Length > 0)
                {
                    string controlString = tokens.Last();
                    if (!string.IsNullOrEmpty(controlString) && controlString.Length >= 2)
                    {
                        info.IsEnabled = (controlString[1] == '1');
                    }
                }
            }
            catch
            {
                // ignore parse errors; return what we have
            }

            return true;
        }

        public string SetAllParams(double setTemp, double setHumidity, bool enableChamber)
        {
            if (_transport == null || !_transport.IsOpen || _currentModel == ChamberModel.UNKNOWN)
                return "ERROR: Chamber not connected or model unknown.";

            int outState = enableChamber ? 1 : 0;
            string command;

            switch (_currentModel)
            {
                case ChamberModel.V08_VCS_7080_10:
                    command = string.Format("$" + "{0:D2}E {1:000.0} {2:000.0} 0090.0 0005.0 0015.0 0{3}000000000000000000000000000000",
                                             _chamberAddress, setTemp, setHumidity, outState);
                    break;

                case ChamberModel.V26_C7_1000_E:
                    command = string.Format("$" + "{0:D2}E {1:000.0} {2:000.0} 0000.0 0000.0 0000.0 0{3}010000000000000000000000000000",
                                             _chamberAddress, setTemp, setHumidity, outState);
                    break;

                case ChamberModel.W27_ESS_C_1000_70_5:
                    command = string.Format("$" + "{0:D2}E {1:000.0} {2:000.0} 0{3}000000000000000000000000000000",
                                             _chamberAddress, setTemp, setHumidity, outState);
                    break;

                case ChamberModel.W29_ESS_T_1700_70_8:
                    command = string.Format("$" + "{0:D2}E {1:000.0} {2:000.0} 0100.0 0015.0 0005.0 0{3}000000000000000000000000000000",
                                             _chamberAddress, setTemp, setHumidity, outState);
                    break;

                case ChamberModel.W28_ESS_C_1300_70_10:
                case ChamberModel.UNKNOWN:
                default:
                    command = string.Format("$" + "{0:D2}E {1:000.0} {2:000.0} 0080.0 0015.0 0000.0 0{3}000000000000000000000000000000",
                                             _chamberAddress, setTemp, setHumidity, outState);
                    break;
            }

            return SendCommand(command);
        }

        public string GetAllParams()
        {
            if (_transport == null || !_transport.IsOpen) return "Port not open.";

            string command = string.Format("$" + "{0:D2}I", _chamberAddress);
            return SendCommand(command);
        }

        private string SendCommand(string command)
        {
            lock (_commLock)
            {
                try
                {
                    if (_transport == null || !_transport.IsOpen) return "COMM_ERROR: Not connected";
                    _transport.DiscardBuffers();
                    _transport.WriteLine(command);
                    // Increased timeout for network transports
                    string response = _transport.ReadLine(5000);
                    return response?.Trim() ?? string.Empty;
                }
                catch (TimeoutException)
                {
                    return "TIMEOUT";
                }
                catch (Exception ex)
                {
                    return $"COMM_ERROR: {ex.Message}";
                }
            }
        }

        public bool ParseGetParamsResponse(string response,
                                       out double setTemp, out double currentTemp,
                                       out double setHumi, out double currentHumi,
                                       out bool isEnabled)
        {
            setTemp = currentTemp = setHumi = currentHumi = 0;
            isEnabled = false;

            if (string.IsNullOrEmpty(response) || response.Contains("ERROR")) return false;

            try
            {
                string[] values = response.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length < 5) return false;

                if (!double.TryParse(values[0], out setTemp)) return false;
                if (!double.TryParse(values[1], out currentTemp)) return false;
                if (!double.TryParse(values[2], out setHumi)) return false;
                if (!double.TryParse(values[3], out currentHumi)) return false;

                string controlString = values.Last();
                if (!string.IsNullOrEmpty(controlString) && controlString.Length >= 2)
                {
                    isEnabled = (controlString[1] == '1');
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
