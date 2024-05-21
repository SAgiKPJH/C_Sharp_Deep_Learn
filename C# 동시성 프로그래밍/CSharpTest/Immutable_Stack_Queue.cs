using System.Collections.Immutable;
using System.Diagnostics;

namespace CSharpTest
{
    internal class Immutable_Stack_Queue
    {
        public Immutable_Stack_Queue()
        {
            ImmutableStack<int> stack = ImmutableStack<int>.Empty;

            stack = stack.Push(13);

            ImmutableStack<int> biggerStack = stack.Push(7);

            foreach (int item in biggerStack)
                Trace.WriteLine(item); // 7, 13

            foreach (int item in stack)
                Trace.WriteLine(item); // 13 (Snap Shot) (13은 Memory 공유)

            int lastItem;
            stack = stack.Pop(out lastItem);
            Trace.WriteLine(lastItem); // 13



            ImmutableQueue<int> queue = ImmutableQueue<int>.Empty;

            queue = queue.Enqueue(13);

            ImmutableQueue<int> biggerQueue = queue.Enqueue(7);

            foreach (int item in biggerQueue)
                Trace.WriteLine(item); // 13, 7

            foreach (int item in queue)
                Trace.WriteLine(item); // 13 (Snap Shot) (13은 Memory 공유)

            int nextItem;
            queue = queue.Dequeue(out nextItem);
            Trace.WriteLine(nextItem); // 13
        }
    }
}

