using DevExpress.Mvvm.CodeGenerators;
using DevExpress.Mvvm.Native;
using DevExpress.XtraPrinting.Preview;
using Microsoft.Extensions.Logging;
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
        // CancellationToken을 활용한 15초 뒤 종료 동작
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(15));

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

            // CancellationToken 미 지원 Handeling -> IsCancellationRequested
            MouseDownCommand = ReactiveCommand.Create<MouseButtonEventArgs, Unit>(e =>
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested)
                    listSource.Add($"Canceled");
                else
                    listSource.Add($"Mouse Down!!!!!");
                
                return Unit.Default;
            });

            SynchronizationContext uiContext = SynchronizationContext.Current;

            MouseDownCommand
                .Buffer(MouseDownCommand.Throttle(TimeSpan.FromMilliseconds(1000)))
                .Where(x => x.Count >= 2)
                .ObserveOn(uiContext)
                .Subscribe(position =>
                {
                    string output = position.Count >= 3 ? "Triple" : "Double";
                    listSource.Add($"Mouse {output} Click!!!!!");
                },_cancellationTokenSource.Token);

            // CancellationToken Register 기능
            _cancellationTokenSource.Token.Register(() =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    listSource.Add($"Regist Cancel Action Works");
                });
            });
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
