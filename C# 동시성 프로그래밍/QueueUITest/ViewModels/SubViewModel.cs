using DevExpress.Mvvm.CodeGenerators;
using DevExpress.Mvvm.Native;
using QueueUITest.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Windows.Input;

namespace QueueUITest.ViewModels
{
    [GenerateViewModel]
    public partial class SubViewModel
    {
        private IQueue _queueService;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        [GenerateProperty]
        ObservableCollection<string> data = ["a", "b"];

        [GenerateProperty]
        public string text = "Nomal";

        [GenerateProperty]
        ObservableCollection<string> listSource = new() { "First" };

        public ReactiveCommand<MouseButtonEventArgs, Unit> MouseDownCommand { get; private set; }

        public SubViewModel(IQueue queueService)
        {
            _queueService = queueService;
            _queueService.MessageEvent += (e, receive) =>
            {
                data.Add(receive);
            };

            MouseDownCommand = ReactiveCommand.Create<MouseButtonEventArgs, Unit>(e =>
            {
                listSource.Add($"Mouse Down!!!!!");
                return Unit.Default;
            });

            SynchronizationContext uiContext = SynchronizationContext.Current;

            var untilObservable = Observable.Timer(TimeSpan.FromSeconds(15)).Take(1);

            MouseDownCommand
                .Buffer(MouseDownCommand.Throttle(TimeSpan.FromMilliseconds(1000)))
                .Where(x => x.Count >= 2)
                .TakeUntil(untilObservable)
                .ObserveOn(uiContext)
                .Subscribe(position =>
                {
                    string output = position.Count >= 3 ? "Triple" : "Double";
                    listSource.Add($"Mouse {output} Click!!!!!");
                },
                onCompleted: () =>
                {
                    listSource.Add($"Cancel");
                    _cancellationTokenSource.Cancel();
                }, _cancellationTokenSource.Token);
        }

        [GenerateCommand]
        void Send() => _queueService.Send("SubView_Send");

        [GenerateCommand]
        void Excute() => Text = "";

        [GenerateCommand]
        void Cancel()
        {
            _queueService.CancellationTokenSource.Cancel();
            _cancellationTokenSource.Cancel();
        }
    }
}
