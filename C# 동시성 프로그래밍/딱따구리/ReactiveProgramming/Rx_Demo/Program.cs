using Rx_Demo;

//var evenNumber = new EvneNumberObservable();
//var consoleObserver = new ConsoleLogObserver();
//evenNumber.Subscribe(consoleObserver);

var evenNumber = new EvenNumberSubject();
evenNumber.Subscribe(Console.WriteLine);
evenNumber.Run();

Console.WriteLine("Completed!");
Console.ReadLine();
