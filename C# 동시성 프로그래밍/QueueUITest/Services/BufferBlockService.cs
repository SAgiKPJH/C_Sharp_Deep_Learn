using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace QueueUITest.Services
{
    public class BufferBlockService : IQueue
    {
        private BufferBlock<string> _queue = new BufferBlock<string>(new DataflowBlockOptions { BoundedCapacity = 1 });
        public EventHandler<string> MessageEvent { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

        public BufferBlockService()
        {
            Receive(CancellationTokenSource.Token);
        }

        public async void Receive(CancellationToken cancellationToken)
        {
            while (true)
            {
                string Item;
                try
                {
                    Item = await _queue.ReceiveAsync();
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
