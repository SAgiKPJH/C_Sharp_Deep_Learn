namespace AsyncTest;

class Program
{
    public static event EventHandler events;
    static async Task Main(string[] args)
    {
        events += async (e, v) => await Sync();

        events?.Invoke(null, EventArgs.Empty);

        Sync2();

        await Task.CompletedTask;
    }

    public static async Task Sync()
    {
        while (true)
        {
            Console.WriteLine("This is Sync1");
            await Task.Delay(1000);
        }
    }

    public static void Sync2()
    {
        while (true)
        {
            Console.WriteLine("This is Sync2");
            Task.WaitAll(Task.Delay(1000));
        }
    }
}
