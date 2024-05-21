using Nito.AsyncEx;
using System;

namespace QueueUITest.Services
{
    public class AsyncProducerConsumerQueueService : IQueue
    {
        private AsyncProducerConsumerQueue<string> _message = new AsyncProducerConsumerQueue<string>();
        public EventHandler<string> MessageEvent { get; set; }

        public AsyncProducerConsumerQueueService()
        {
            Receive();
        }

        public async void Send(string message)
        {
            await _message.EnqueueAsync(message);
        }

        public async void Receive()
        {
            while (true)
            {
                string item;
                try
                {
                    item = await _message.DequeueAsync();
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
