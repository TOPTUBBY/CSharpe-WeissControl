using System;

namespace Form1
{
    public interface ITransport : IDisposable
    {
        bool Connect();

        void Disconnect();

        bool IsOpen { get; }

        void WriteLine(string line);

        /// <summary>อ่านบรรทัดจนถึง CR (\r) หรือจนกว่าจะหมดเวลา (ms)</summary>
        string ReadLine(int timeoutMs);

        void DiscardBuffers();
    }
}