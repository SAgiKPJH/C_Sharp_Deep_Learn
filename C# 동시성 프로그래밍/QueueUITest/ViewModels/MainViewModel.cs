using DevExpress.Mvvm.CodeGenerators;
using DevExpress.XtraPrinting.Preview;
using QueueUITest.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Input;

namespace QueueUITest.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        private IQueue _queueService;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        [GenerateProperty]
        ObservableCollection<string> data = ["a", "b"];

        [GenerateProperty]
        public string text = "Nomal";

        [GenerateProperty]
        string _UserName;

        [GenerateProperty]
        ObservableCollection<string> listSource = new() { "First" };

        public ReactiveCommand<MouseButtonEventArgs, Unit> MouseDownCommand { get; private set; }

        public MainViewModel(IQueue queueService)
        {
            _queueService = queueService;
            _queueService.MessageEvent += (e, receive) =>
            {
                data.Add(receive);
            };

            // CancellationToken 미 지원 Handeling -> Throw
            MouseDownCommand = ReactiveCommand.Create<MouseButtonEventArgs, Unit>(e =>
            {
                try
                {
                    _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    listSource.Add($"Mouse Down!!!!!");
                }
                catch (OperationCanceledException)
                {
                    listSource.Add($"Canceled");
                }
                return Unit.Default;
            });

            SynchronizationContext uiContext = SynchronizationContext.Current;

            var untilObservable = Observable.Timer(TimeSpan.FromSeconds(20)).Take(1);

            MouseDownCommand
                .Buffer(MouseDownCommand.Throttle(TimeSpan.FromMilliseconds(200)))
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
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        // Observable을 활용한 Cancel 동작
                        listSource.Add($"Been 15 Seconed");
                    });
                    _cancellationTokenSource.Cancel();
                }, _cancellationTokenSource.Token);
        }

        [GenerateCommand]
        void Send() => _queueService.Send("MainView_Send");

        [GenerateCommand]
        void Excute() => Text = "no";

        [GenerateCommand]
        void Cancel()
        {
            _queueService.CancellationTokenSource.Cancel();
            _cancellationTokenSource.Cancel();
        }
    }
}
