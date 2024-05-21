using System.Collections.Immutable;
using System.Diagnostics;

namespace CSharpTest
{
    internal class Immutable_HashSet_SortedSet
    {
        public Immutable_HashSet_SortedSet()
        {
            ImmutableHashSet<int> hash = ImmutableHashSet<int>.Empty;

            hash = hash.Add(13);

            ImmutableHashSet<int> hashSet = hash.Add(7);

            foreach (int item in hashSet)
                Trace.WriteLine(item); // 7, 13을 임의의 순서로 표시

            foreach (int item in hash)
                Trace.WriteLine(item); // 13 (Snap Shot) (13은 Memory 공유)

            hashSet = hashSet.Remove(7);



            ImmutableSortedSet<int> sorted = ImmutableSortedSet<int>.Empty;

            sorted = sorted.Add(13);

            ImmutableSortedSet<int> sortedSet = sorted.Add(7);

            foreach (int item in sortedSet)
                Trace.WriteLine(item); // 7, 13

            foreach (int item in sorted)
                Trace.WriteLine(item); // 13 (Snap Shot) (13은 Memory 공유)

            int smallestItem = sortedSet[0];
            Trace.WriteLine(smallestItem); // 7
            sortedSet = sortedSet.Remove(7);
        }
    }
}
