using Nito.AsyncEx;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace CSharpTest
{
    internal class AsyncCollection_
    {
        public AsyncCollection_() { }

        public async void ss()
        {
            var _asyncStack = new AsyncCollection<int>(new ConcurrentStack<int>(), maxCount: 1); // 후입 선출
            var _asyncBag = new AsyncCollection<int>(new ConcurrentBag<int>()); // 순서가 없는 백

            // 생산자
            await _asyncStack.AddAsync(7);
            await _asyncStack.AddAsync(13);
            _asyncStack.CompleteAdding();

            // 소비자
            while (await _asyncStack.OutputAvailableAsync())
                Trace.WriteLine(await _asyncStack.TakeAsync()); // 13, 7
        }

        public async void AsyncBufferBlock()
        {
            var queue = new BufferBlock<int>();

            // 생산자 코드
            await queue.SendAsync(7);
            await queue.SendAsync(13);
            queue.Complete();

            // 단일 소비자
            while (await queue.OutputAvailableAsync())
                Trace.WriteLine(await queue.ReceiveAsync());

            // 복수 소비자
            while (true)
            {
                int Item;
                try
                {
                    Item = await queue.ReceiveAsync();
                }
                catch (InvalidOperationException)
                {
                    break;
                }

                Trace.WriteLine(Item);
            }
        }
        public void SyncBufferBlock()
        {
            var queue = new BufferBlock<int>();

            // 생산자 코드
            queue.Post(7);
            queue.Post(13);
            queue.Complete();

            // 소비자
            while (true)
            {
                int Item;
                try
                {
                    Item = queue.Receive();
                }
                catch (InvalidOperationException)
                {
                    break;
                }

                Trace.WriteLine(Item);
            }
        }

        public async void TPL_ActionBlock()
        {
            ActionBlock<int> queue = new ActionBlock<int>(item => Trace.WriteLine(item));

            await queue.SendAsync(7);
            await queue.SendAsync(13);

            queue.Post(7);
            queue.Post(13);

            queue.Complete();
        }

        public async void AsyncProducerConsumerQueue_()
        {
            var queue = new AsyncProducerConsumerQueue<int>();

            await queue.EnqueueAsync(7);
            await queue.EnqueueAsync(13);

            queue.Enqueue(7);
            queue.Enqueue(13);

            queue.CompleteAdding();

            // 비동기
            while (await queue.OutputAvailableAsync())
                Trace.WriteLine(await queue.DequeueAsync());

            while (true)
            {
                int item;
                try
                {
                    item = await queue.DequeueAsync();
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                Trace.WriteLine(item);
            }

            // 동기
            foreach (int item in queue.GetConsumingEnumerable())
                Trace.WriteLine(item);
        }
    }
}
