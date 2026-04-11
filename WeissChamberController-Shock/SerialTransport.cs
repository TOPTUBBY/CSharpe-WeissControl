using System;
using System.IO.Ports;

namespace Form1
{
    public class SerialTransport : ITransport
    {
        private SerialPort _port;
        private readonly string _portName;
        private readonly int _baudRate;
        private readonly string _eol = "\r";

        public SerialTransport(string portName, int baudRate)
        {
            _portName = portName;
            _baudRate = baudRate;
        }

        public bool Connect()
        {
            try
            {
                _port = new SerialPort(_portName, _baudRate, Parity.None, 8, StopBits.One);
                _port.Handshake = Handshake.None;
                _port.DtrEnable = true;
                _port.ReadTimeout = 2000;
                _port.WriteTimeout = 500;
                _port.NewLine = _eol;
                _port.Open();
                return _port.IsOpen;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_port != null)
                {
                    if (_port.IsOpen) _port.Close();
                    _port.Dispose();
                    _port = null;
                }
            }
            catch { }
        }

        public bool IsOpen => _port?.IsOpen ?? false;

        public void WriteLine(string line)
        {
            if (_port == null) throw new InvalidOperationException("Serial port not initialized");
            _port.Write(line + _eol);
        }

        public string ReadLine(int timeoutMs)
        {
            if (_port == null) throw new InvalidOperationException("Serial port not initialized");
            _port.ReadTimeout = timeoutMs;
            return _port.ReadLine();
        }

        public void DiscardBuffers()
        {
            try
            {
                _port?.DiscardInBuffer();
                _port?.DiscardOutBuffer();
            }
            catch { }
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}