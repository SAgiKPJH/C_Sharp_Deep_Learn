using Nito.AsyncEx;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CSharpTest
{
    internal class AsyncQueue
    {
        public AsyncQueue() { }

        public async void Channel_()
        {
            Channel<int> queue = Channel.CreateUnbounded<int>();

            // 생산자
            ChannelWriter<int> writer = queue.Writer;
            await writer.WriteAsync(7);
            await writer.WriteAsync(13);
            writer.Complete(); // 앞으로 항목이 더 없다고 알림

            // 소비자
            ChannelReader<int> reader = queue.Reader;
            await foreach (var item in reader.ReadAllAsync())
                Trace.WriteLine(item);
        }

        public async void BufferBlock_()
        {
            var _asyncQueue = new BufferBlock<int>();

            // 생산자 코드
            await _asyncQueue.SendAsync(7);
            await _asyncQueue.SendAsync(13);
            _asyncQueue.Complete();

            // 소비자 코드
            while(await _asyncQueue.OutputAvailableAsync()) // 소비자가 하나일 때 유용
                Trace.WriteLine(await _asyncQueue.ReceiveAsync());

            // 여러 소비자
            while (true)
            {
                int item;
                try
                {
                    item = await _asyncQueue.ReceiveAsync();
                }
                catch(InvalidOperationException)
                {
                    break;
                }
                Trace.WriteLine(item);
            }
        }

        public async void AsyncProducerConsumerQueue_()
        {
            var _asyncQueue = new AsyncProducerConsumerQueue<int>();

            // 생산자
            await _asyncQueue.EnqueueAsync(7);
            await _asyncQueue.EnqueueAsync(13);
            _asyncQueue.CompleteAdding();

            // 소비자
            while(await _asyncQueue.OutputAvailableAsync())
                Trace.WriteLine(await _asyncQueue.DequeueAsync());

            // 소비자 여럿
            while (true)
            {
                int item;
                try
                {
                    item = await _asyncQueue.DequeueAsync();
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                Trace.WriteLine(item);
            }
        }

        public async void 조절()
        {
            Channel<int> _channelQueue = Channel.CreateBounded<int>(1);
            ChannelWriter<int> writer = _channelQueue.Writer;

            await writer.WriteAsync(7);
            await writer.WriteAsync(13); // 7의 삭제를 비동기적으로 대기
            writer.Complete();



            var _bufferBlockQueue = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = 1 });
            
            await _bufferBlockQueue.SendAsync(7);
            await _bufferBlockQueue.SendAsync(13); // 7의 삭제를 비동기적으로 대기



            var _asyncQueue = new AsyncProducerConsumerQueue<int>(maxCount: 1);
            await _asyncQueue.EnqueueAsync(7);
            await _asyncQueue.EnqueueAsync(13); // 7의 삭제를 비동기적으로 대기


            var queue = new BlockingCollection<int>(boundedCapacity: 1);
            queue.Add(7);
            queue.Add(13); // 7의 삭제를 대기
            queue.CompleteAdding();
        }

        public async void QueueSampling()
        {
            Channel<int> queue = Channel.CreateBounded<int>(
                new BoundedChannelOptions(1)
                {
                    FullMode = BoundedChannelFullMode.DropOldest // 오래된 것을 제거
                    // FullMode = BoundedChannelFullMode.DropWrite // 가장 최신 것을 제거
                });
            ChannelWriter<int> writer = queue.Writer;

            await writer.WriteAsync(7);
            await writer.WriteAsync(13); // 7을 가져가지 않았으면 7 삭제
        }
    }
}
