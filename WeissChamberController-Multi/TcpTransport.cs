using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Form1
{
    public class TcpTransport : ITransport
    {
        private readonly string _host;
        private readonly int _port;
        private TcpClient _client;
        private NetworkStream _stream;
        private readonly string _eol = "\r";

        public TcpTransport(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public bool Connect()
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(_host, _port);
                _stream = _client.GetStream();
                _stream.ReadTimeout = 2000;
                return _client.Connected;
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
                _stream?.Close();
                _client?.Close();
                _stream = null;
                _client = null;
            }
            catch { }
        }

        public bool IsOpen => _client?.Connected ?? false;

        public void WriteLine(string line)
        {
            if (_stream == null) throw new InvalidOperationException("TCP stream not initialized");
            var data = Encoding.ASCII.GetBytes(line + _eol);
            _stream.Write(data, 0, data.Length);
            _stream.Flush();
        }

        public string ReadLine(int timeoutMs)
        {
            if (_stream == null) throw new InvalidOperationException("TCP stream not initialized");
            var sb = new StringBuilder();
            var buffer = new byte[1];
            var sw = System.Diagnostics.Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                try
                {
                    if (_stream.DataAvailable)
                    {
                        int r = _stream.Read(buffer, 0, 1);
                        if (r == 0) break;
                        char c = (char)buffer[0];
                        if (c == '\r') break;
                        sb.Append(c);
                    }
                    else
                    {
                        Thread.Sleep(5);
                    }
                }
                catch (System.IO.IOException)
                {
                    break;
                }
            }

            return sb.ToString();
        }

        public void DiscardBuffers()
        {
            try
            {
                if (_stream == null) return;
                while (_stream.DataAvailable)
                {
                    var tmp = new byte[256];
                    _stream.Read(tmp, 0, tmp.Length);
                }
            }
            catch { }
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
