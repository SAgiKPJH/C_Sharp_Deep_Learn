using Nito.AsyncEx;
using System;
using System.Threading;

namespace QueueUITest.Services
{
    public class AsyncProducerConsumerQueueService : IQueue
    {
        private AsyncProducerConsumerQueue<string> _message = new AsyncProducerConsumerQueue<string>();
        public EventHandler<string> MessageEvent { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

        public AsyncProducerConsumerQueueService()
        {
            Receive(CancellationTokenSource.Token);
        }

        public async void Send(string message)
        {
            await _message.EnqueueAsync(message);
        }

        public async void Receive(CancellationToken cancellationToken)
        {
            while (true)
            {
                string item;
                try
                {
                    item = await _message.DequeueAsync(cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    MessageEvent?.Invoke(this, "Cancel");
                    break;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                MessageEvent?.Invoke(this, item);
            }
        }
    }
}