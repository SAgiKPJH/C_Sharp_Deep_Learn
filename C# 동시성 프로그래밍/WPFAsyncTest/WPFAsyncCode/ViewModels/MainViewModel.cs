using DevExpress.Mvvm.CodeGenerators;
using System.Threading.Tasks;
using System;

namespace WPFAsyncCode.ViewModels;

[GenerateViewModel]
public partial class MainViewModel
{
    public event EventHandler events;

    [GenerateProperty]
    string _Status;
    [GenerateProperty]
    string _UserName;

    [GenerateCommand]
    void test1()
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
    }
}
