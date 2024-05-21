using System;

namespace QueueUITest.Services
{
    public interface IQueue
    {
        EventHandler<string> MessageEvent { get; set; }
        void Send(string message);
        void Receive();
    }
}