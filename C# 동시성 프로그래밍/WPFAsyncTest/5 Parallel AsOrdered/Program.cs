

Console.WriteLine("Hello, World!");

int parallelsum(IEnumerable<int> values)
{
    object mutex = new object();
    int result = 0;
    Parallel.ForEach(
        source: values,
        localInit: () =>
        {
            return 10;
        },
        body: (item, state, loclValue) =>
        {
            return loclValue + item;
        },
        localFinally: localValue =>
        {
            lock (mutex)
                result += localValue;
        });
    return result;
}


List<int> list = new List<int>() { 1,2,3 };
int result = parallelsum(list);
Console.WriteLine(result);