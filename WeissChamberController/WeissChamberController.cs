using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace Form1
{
    public class WeissChamberController
    {
        private SerialPort _serialPort;
        private int _chamberAddress = 1;
        private readonly string _eol = "\r";
        private ChamberModel _currentModel = ChamberModel.UNKNOWN;

        public ChamberModel CurrentModel
        {
            get { return _currentModel; }
        }

        public enum ChamberModel
        {
            UNKNOWN,
            V08_VCS_7080_10,
            V26_C7_1000_E,
            W27_ESS_C_1000_70_5,
            W28_ESS_C_1300_70_10,
            W29_ESS_T_1700_70_8
        }

        /// <summary>
        /// Initialize and open the serial port connection to the chamber.
        /// </summary>
        public bool InitializeSerialPort(string portName, int baudRate = 9600, int address = 1)
        {
            try
            {
                _chamberAddress = address;

                if (_serialPort != null && _serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                _serialPort.Handshake = Handshake.None;
                _serialPort.DtrEnable = true;
                _serialPort.ReadTimeout = 2000;
                _serialPort.WriteTimeout = 500;
                _serialPort.NewLine = _eol;
                _serialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening serial port: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Close and dispose the serial port connection.
        /// </summary>
        public void Disconnect()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }

        /// <summary>
        /// Sends an ID request ($01I) and determines the chamber model
        /// based on the response format and known identifiers.
        /// </summary>
        public ChamberModel CheckChamberModel()
        {
            if (_serialPort == null || !_serialPort.IsOpen) return ChamberModel.UNKNOWN;

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

            // Models with 7 values (V08 or W28)
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
            // Models with 5 values (V26 W27 or W29)
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
        /// Sends a Set Parameters command to configure chamber setpoints and enable/disable state.
        /// </summary>
        public string SetAllParams(double setTemp, double setHumidity, bool enableChamber)
        {
            if (_serialPort == null || !_serialPort.IsOpen || _currentModel == ChamberModel.UNKNOWN)
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
                    command = string.Format("$" + "{0:D2}E {1:000.0} {2:000.0} 0000.0 0000.0 0000.0 0{3}000000000000000000000000000000",
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

        /// <summary>
        /// Sends a Get Parameters command to retrieve all chamber values.
        /// </summary>
        public string GetAllParams()
        {
            if (_serialPort == null || !_serialPort.IsOpen) return "Port not open.";

            string command = string.Format("$" + "{0:D2}I", _chamberAddress);
            return SendCommand(command);
        }

        /// <summary>
        /// Core function to send a command and read the response.
        /// </summary>
        private string SendCommand(string command)
        {
            try
            {
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                _serialPort.Write(command + _eol);

                string response = _serialPort.ReadLine();
                return response.Trim();
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

        /// <summary>
        /// Parse the response from Get Parameters command.
        /// Extracts setpoints, actual values, and chamber ON/OFF state.
        /// </summary>
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
                if (controlString.Length >= 32)
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
