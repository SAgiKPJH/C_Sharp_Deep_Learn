using Rx_Demo;
using System.Reactive.Linq;

//var evenNumber = new EvneNumberObservable();
//var consoleObserver = new ConsoleLogObserver();
//evenNumber.Subscribe(consoleObserver);

//var evenNumber = new EvenNumberSubject();
//evenNumber.Run();
//evenNumber.Subscribe(Console.WriteLine);

Observable.Range(1, 100)
    .Where(x => x % 2 == 0)
    .Take(10)
    .Merge(Observable.Range(1, 100).Where(x => x % 2 == 0).Take(10))
    .Select(x => $"Even Number {x}")
    .Subscribe(Console.WriteLine);

Console.WriteLine("Completed!");
Console.ReadLine();
