using Nito.AsyncEx;
using System;

namespace QueueUITest.Services
{
    public class AsyncProducerConsumerQueueService : IQueue
    {
        public AsyncProducerConsumerQueue<string> Message = new AsyncProducerConsumerQueue<string>();
        public EventHandler<string> MessageEvent { get; set; }

        public AsyncProducerConsumerQueueService()
        {
            Receive();
        }

        public async void Send(string message)
        {
            await Message.EnqueueAsync(message);
        }

        public async void Receive()
        {
            while (true)
            {
                string item;
                try
                {
                    item = await Message.DequeueAsync();
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
