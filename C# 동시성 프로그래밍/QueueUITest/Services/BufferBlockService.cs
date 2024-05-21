using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace QueueUITest.Services
{
    public class BufferBlockService : IQueue
    {
        private BufferBlock<string> _queue = new BufferBlock<string>(new DataflowBlockOptions { BoundedCapacity = 1 });
        public EventHandler<string> MessageEvent { get; set; }

        public BufferBlockService()
        {
            Receive();
        }

        public async void Receive()
        {
            while (true)
            {
                string Item;
                try
                {
                    Item = await _queue.ReceiveAsync();
                }
                catch (InvalidOperationException)
                {
                    break;
                }

                MessageEvent?.Invoke(this, Item);
                await Task.Delay(1000);
            }
        }

        public async void Send(string message)
        {
            await _queue.SendAsync(message);
        }
    }
}
