namespace AsyncTest;

class Program
{
    static async Task Main(string[] args)
    {
        async IAsyncEnumerable<int> GetAsyncNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100); // 비동기 작업을 가정
                yield return i;
                yield return i + 10;
            }
        }

        // 사용 예
        await foreach (var number in GetAsyncNumbers())
        {
            Console.WriteLine(number);
        }
    }
}
