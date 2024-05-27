using DevExpress.Xpf.Core;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Input;

namespace DXApplication_RP_Not_MVVM
{
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            SynchronizationContext uiContext = SynchronizationContext.Current;

            var listSource = new ObservableCollection<string>() { "First" };
            list.ItemsSource = listSource;

            var mouseDown = Observable.FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(
                h => new MouseButtonEventHandler(h),
                h => this.MouseDown += h,
                h => this.MouseDown -= h);


            mouseDown.Select(e => e.EventArgs.GetPosition(this))
                .Subscribe(position =>
            {
                listSource.Add($"Mouse Down!!!!!   ({position.X}, {position.Y})");
            });

            mouseDown
                .Select(e => e.EventArgs.GetPosition(this))
                .Buffer(mouseDown.Throttle(TimeSpan.FromMilliseconds(200))) // 별도 Thread에서 동작
                .Where(x => x.Count >= 2)
                .ObserveOn(uiContext) // 구독을 UI 스레드에서 실행하도록 지정
                .Subscribe(position =>
                {
                    string output = position.Count >= 3 ? "Triple" : "Double";
                    listSource.Add($"Mouse {output} Click!!!!!   ({position[0].X}, {position[0].Y})");
                });
        }
    }
}
