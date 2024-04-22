using Rx_Demo;

var evenNumber = new EvneNumberObservable();
var consoleObserver = new ConsoleLogObserver();
evenNumber.Subscribe(consoleObserver);

Console.WriteLine("Completed!");
Console.ReadLine();
