using Nito.AsyncEx;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace QueueUITest.Services
{
    public class AsyncCollectionService : IQueue
    {
        private AsyncCollection<string> _asyncStack = new AsyncCollection<string>(new ConcurrentStack<string>(), maxCount: 1);
        public EventHandler<string> MessageEvent {get; set;}
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

        public AsyncCollectionService()
        {
            Receive(CancellationTokenSource.Token);
        }

        public async void Receive(CancellationToken cancellationToken)
        {
            while (await _asyncStack.OutputAvailableAsync())
                MessageEvent?.Invoke(this, await _asyncStack.TakeAsync());
        }

        public async void Send(string message)
        {
            await _asyncStack.AddAsync(message);
        }
    }
}
