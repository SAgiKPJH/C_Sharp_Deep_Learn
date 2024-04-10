namespace AsyncTest;

class Program
{
    static void Main(string[] args)
    {
        Sync();
        Sync2();
    }

    public static void Sync()
    {
        while(true)
        {
            Console.WriteLine("This is Sync1");
            Task.WaitAll(Task.Delay(1000));
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