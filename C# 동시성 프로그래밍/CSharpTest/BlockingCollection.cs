using System.Collections.Concurrent;
using System.Diagnostics;

namespace CSharpTest
{
    internal class BlockingCollection_
    {
        private readonly BlockingCollection<int> _blockingQueue = new BlockingCollection<int>();
        public BlockingCollection_(BlockingCollection<int> blockingCollection)
        {
            _blockingQueue = blockingCollection;

            // 생성자 스레드
            _blockingQueue.Add(7);
            _blockingQueue.Add(13);
            _blockingQueue.CompleteAdding();

            // 소비자 스레드
            foreach (var item in _blockingQueue.GetConsumingEnumerable()) // Take는 하나의 항목만 소비
                Trace.WriteLine(item);
        }

        public void Blocking_Stack_Back()
        {
            // 후입 선출 (LIFO)
            BlockingCollection<int> _blockingStack = new BlockingCollection<int>(new ConcurrentStack<int>());
            
            // 생산자
            _blockingStack.Add(7);
            _blockingStack.Add(13);
            _blockingStack.CompleteAdding();
            // 소비자
            foreach(var item in _blockingStack.GetConsumingEnumerable())
                Trace.WriteLine(item); // 13, 7, 첫 번째 항목을 반환하기 전에 CompleteAdding 호출을 기다리지 않는다.

            // 순서가 없는 백
            BlockingCollection<int> _blockingBag = new BlockingCollection<int>(new ConcurrentBag<int>());
        }
    }
}
