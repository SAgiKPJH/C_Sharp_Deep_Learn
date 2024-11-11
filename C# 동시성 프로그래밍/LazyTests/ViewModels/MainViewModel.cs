using DevExpress.Mvvm.CodeGenerators;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace LazyTests.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        private bool _isReady = true;
        private int _currentIndex = 0;
        private const int PageSize = 100;
        private readonly Lazy<Task<List<int>>> _lazyData = new Lazy<Task<List<int>>>(GenerateDataAsync);

        [GenerateProperty]
        ObservableCollection<int> data = new();

        
        [GenerateCommand]
        private async Task Click()
        {
            _isReady = false;

            var data = await _lazyData.Value;

            var pagedData = data.Skip(_currentIndex).Take(PageSize).ToList();
            foreach (var item in pagedData)
            {
                Data.Add(item);
            }
            _currentIndex += PageSize;

            _isReady = true;
            await Task.CompletedTask;
        }
        bool CanClick() => _isReady;

        private static async Task<List<int>> GenerateDataAsync()
        {
            return await Task.Run(() => Enumerable.Range(1, 100000000).ToList());
        }
    }
}
