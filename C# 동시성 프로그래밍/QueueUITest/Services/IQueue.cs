using System;
using System.Threading;

namespace QueueUITest.Services
{
    public interface IQueue
    {
        CancellationTokenSource CancellationTokenSource { get; set; }
        EventHandler<string> MessageEvent { get; set; }
        void Send(string message);
        void Receive(CancellationToken cancellationToken);
    }
}