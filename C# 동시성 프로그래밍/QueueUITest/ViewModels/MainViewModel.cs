using DevExpress.Mvvm.CodeGenerators;
using QueueUITest.Services;
using System.Collections.ObjectModel;

namespace QueueUITest.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        private IQueue _queueService;

        [GenerateProperty]
        ObservableCollection<string> data = ["a", "b"];

        [GenerateProperty]
        public string text = "Nomal";

        [GenerateProperty]
        string _UserName;

        public MainViewModel(IQueue queueService)
        {
            _queueService = queueService;
            _queueService.MessageEvent += (e, receive) =>
            {
                data.Add(receive);
            };
        }

        [GenerateCommand]
        void Send() => _queueService.Send("MainView_Send");

        [GenerateCommand]
        void Excute() => Text = "no";
    }
}
