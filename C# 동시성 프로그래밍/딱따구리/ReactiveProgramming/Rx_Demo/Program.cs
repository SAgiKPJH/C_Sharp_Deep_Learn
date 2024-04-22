using Rx_Demo;

//var evenNumber = new EvneNumberObservable();
//var consoleObserver = new ConsoleLogObserver();
//evenNumber.Subscribe(consoleObserver);

var evenNumber = new EvenNumberSubject();
evenNumber.Run();
evenNumber.Subscribe(Console.WriteLine);

Console.WriteLine("Completed!");
Console.ReadLine();
