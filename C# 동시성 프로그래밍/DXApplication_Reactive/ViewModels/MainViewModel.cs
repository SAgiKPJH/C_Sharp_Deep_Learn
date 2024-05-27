using DevExpress.Mvvm.CodeGenerators;
using DevExpress.XtraSpellChecker.Parser;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Input;

namespace DXApplication_Reactive.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        [GenerateProperty]
        ObservableCollection<string> listSource = new() { "First" };

        public ReactiveCommand<MouseButtonEventArgs, Unit> MouseDownCommand { get; private set; }


        public MainViewModel()
        {
            MouseDownCommand = ReactiveCommand.Create<MouseButtonEventArgs, Unit>(e =>
            {
                listSource.Add($"Mouse Down!!!!!");
                return Unit.Default;
            });

            SynchronizationContext uiContext = SynchronizationContext.Current;

            MouseDownCommand
                .Buffer(MouseDownCommand.Throttle(TimeSpan.FromMilliseconds(200)))
                .Where(x => x.Count >= 2)
                .ObserveOn(uiContext)
                .Subscribe(position =>
                {
                    string output = position.Count >= 3 ? "Triple" : "Double";
                    listSource.Add($"Mouse {output} Click!!!!!");
                });
        }
    }
}
