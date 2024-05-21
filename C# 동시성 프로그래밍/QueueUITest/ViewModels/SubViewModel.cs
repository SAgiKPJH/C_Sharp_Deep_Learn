using DevExpress.Mvvm.CodeGenerators;
using QueueUITest.Services;
using System.Collections.ObjectModel;

namespace QueueUITest.ViewModels
{
    [GenerateViewModel]
    public partial class SubViewModel
    {
        private IQueue _queueService;

        [GenerateProperty]
        ObservableCollection<string> data = ["a", "b"];

        [GenerateProperty]
        public string text = "Nomal";

        public SubViewModel(IQueue queueService)
        {
            _queueService = queueService;
            _queueService.MessageEvent += (e, receive) =>
            {
                data.Add(receive);
            };
        }

        [GenerateCommand]
        void Send() => _queueService.Send("SubView_Send");

        [GenerateCommand]
        void Excute() => Text = "";
    }
}
