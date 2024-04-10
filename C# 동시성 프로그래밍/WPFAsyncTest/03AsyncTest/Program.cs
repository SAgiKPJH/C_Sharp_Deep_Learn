namespace AsyncTest;

class Program
{
    public static event EventHandler events;

    static async Task Main(string[] args)
    {
        events += (e, v) =>
        {
            while (true)
            {
                Console.WriteLine("This is InEvent");
                Task.WaitAll(Task.Delay(1000));
            }
        };

        events?.Invoke(null, EventArgs.Empty);

        while (true)
        {
            Console.WriteLine("This is OutEvent");
            Task.WaitAll(Task.Delay(1000));
        }

        await Task.CompletedTask;
    }
}