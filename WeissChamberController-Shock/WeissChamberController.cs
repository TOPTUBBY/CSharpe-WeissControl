using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Linq;

namespace Form1
{
    /// <summary>
    /// DTO สำหรับคืนค่าจากคำสั่ง ID ($01I)
    /// </summary>
    public class ModelInfo
    {
        public WeissChamberController.ChamberModel Model { get; set; } = WeissChamberController.ChamberModel.UNKNOWN;
        public double SetPos { get; set; } = 0;
        public double CurPos { get; set; } = 0;
        public double SetTempCrad { get; set; } = 0;
        public double CurTempCrad { get; set; } = 0;
        public double SetTempHot { get; set; } = 0;
        public double CurTempHot { get; set; } = 0;
        public double SetTempCold { get; set; } = 0;
        public double CurTempCold { get; set; } = 0;
        public double SetCyc { get; set; } = 0;
        public double CurCyc { get; set; } = 0;
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
            W7_Shock,
            W11_Shock
        }

        public WeissChamberController(ITransport transport = null)
        {
            _transport = transport;
        }

        public void SetTransport(ITransport transport)
        {
            try { _transport?.Disconnect(); _transport?.Dispose(); } catch { }
            _transport = transport;
        }

        public bool InitializeConnection()
        {
            if (_transport == null) return false;
            return _transport.Connect();
        }

        public void Disconnect()
        {
            try { _transport?.Disconnect(); _transport?.Dispose(); } catch { }
            _transport = null;
        }

        public ChamberModel CheckChamberModel()
        {
            if (_transport == null || !_transport.IsOpen) return ChamberModel.UNKNOWN;

            string idnCommand = string.Format("${0:D2}I", _chamberAddress);
            string response = SendCommand(idnCommand);

            if (response == "TIMEOUT" || response.StartsWith("COMM_ERROR"))
            {
                return _currentModel;
            }

            string[] tokens = response.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length >= 15)
            {
                _currentModel = ChamberModel.W11_Shock;
            }
            else
            {
                _currentModel = ChamberModel.UNKNOWN;
            }

            return _currentModel;
        }

        public bool TryGetModelAndParams(out ModelInfo info)
        {
            info = new ModelInfo();
            if (_transport == null || !_transport.IsOpen) return false;

            string response = GetAllParams();
            info.RawResponse = response;

            if (string.IsNullOrEmpty(response) || response.Contains("COMM_ERROR") || response == "TIMEOUT")
            {
                info.Model = _currentModel;
                return false;
            }

            bool success = ParseGetParamsResponse(response,
                out double setPos, out double curPos,
                out double setTCrad, out double curTCrad,
                out double setTHot, out double curTHot,
                out double setTCold, out double curTCold,
                out double setCyc, out double curCyc,
                out bool isEnabled);

            if (success)
            {
                string[] tokens = response.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length >= 15) _currentModel = ChamberModel.W11_Shock;

                info.Model = _currentModel;
                info.SetPos = setPos; info.CurPos = curPos;
                info.SetTempCrad = setTCrad; info.CurTempCrad = curTCrad;
                info.SetTempHot = setTHot; info.CurTempHot = curTHot;
                info.SetTempCold = setTCold; info.CurTempCold = curTCold;
                info.SetCyc = setCyc; info.CurCyc = curCyc;
                info.IsEnabled = isEnabled;
                return true;
            }

            return false;
        }

        public string SetAllParams(int cradPosSet, double tCradSet, double tHotSet, double tColdSet, int cycleSet, bool enableChamber)
        {
            if (_transport == null || !_transport.IsOpen || _currentModel == ChamberModel.UNKNOWN)
                return "ERROR: Chamber not connected.";

            int outState = enableChamber ? 1 : 0;

            string command = string.Format("${0:D2}E {1:0000.0} {2:000.0} {3:000.0} {4:000.0} 0000.0 {5:0000.0} 0000.0 0000.0 0003.0 0{6}000000000000000000000000000000",
                                            _chamberAddress, (double)cradPosSet, tCradSet, tHotSet, tColdSet, (double)cycleSet, outState);

            return SendCommand(command);
        }

        public string GetAllParams()
        {
            if (_transport == null || !_transport.IsOpen) return "Port not open.";
            string command = string.Format("${0:D2}I", _chamberAddress);
            return SendCommand(command);
        }

        private string SendCommand(string command)
        {
            lock (_commLock)
            {
                try
                {
                    _transport.DiscardBuffers();
                    _transport.WriteLine(command);
                    string response = _transport.ReadLine(5000);
                    return response?.Trim() ?? string.Empty;
                }
                catch (TimeoutException) { return "TIMEOUT"; }
                catch (Exception ex) { return $"COMM_ERROR: {ex.Message}"; }
            }
        }

        /// <summary>
        /// ฟังก์ชัน Parse ข้อมูลจาก string ตอบกลับ
        /// ปรับปรุงลำดับ Token ตาม Response จริงจากเครื่อง Shock Chamber
        /// </summary>
        public bool ParseGetParamsResponse(string response,
                                       out double setPosCradle, out double currentPosCradle,
                                       out double setTempCradle, out double currentTempCradle,
                                       out double setTempHotCham, out double currentTempHotCham,
                                       out double setTempColdCham, out double currentTempColdCham,
                                       out double setCycle, out double currentCycle,
                                       out bool isEnabled)
        {
            setPosCradle = currentPosCradle = setCycle = currentCycle = 0;
            setTempCradle = currentTempCradle = setTempHotCham = currentTempHotCham = setTempColdCham = currentTempColdCham = 0;
            isEnabled = false;

            if (string.IsNullOrEmpty(response) || response.Contains("ERROR")) return false;

            try
            {
                string[] values = response.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length < 12) return false;

                // Index 0, 1: Cradle Position (Set, Cur)
                double.TryParse(values[0], out setPosCradle);
                double.TryParse(values[1], out currentPosCradle);

                // Index 2, 3: Temp Cradle (Set, Cur) - *** นี่คือจุดที่แก้ไขตามภาพของคุณ ***
                double.TryParse(values[2], out setTempCradle);
                double.TryParse(values[3], out currentTempCradle);

                // Index 4, 5: Temp Hot Chamber (Set, Cur)
                double.TryParse(values[4], out setTempHotCham);
                double.TryParse(values[5], out currentTempHotCham);

                // Index 6, 7: Temp Cold Chamber (Set, Cur)
                double.TryParse(values[6], out setTempColdCham);
                double.TryParse(values[7], out currentTempColdCham);

                // Index 10, 11: Cycles (Set, Cur)
                double.TryParse(values[10], out setCycle);
                double.TryParse(values[11], out currentCycle);

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