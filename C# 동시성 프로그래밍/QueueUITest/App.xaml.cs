using DevExpress.Xpf.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueUITest.Services;
using QueueUITest.ViewModels;
using System;
using System.Windows;

namespace QueueUITest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<SubViewModel>();
            services.AddSingleton<MainViewModel>();
            // services.AddSingleton<IQueue, AsyncProducerConsumerQueueService>();
            // services.AddSingleton<IQueue, AsyncCollectionService>();
            services.AddSingleton<IQueue, BufferBlockService>();
        }).Build();

        static App()
        {
            CompatibilitySettings.UseLightweightThemes = true;
        }
        object Resolve(Type type, object key, string name) => _host.Services.GetService(type) ?? default!;

        protected override void OnStartup(StartupEventArgs e)
        {
            DependencySource.Resolver = Resolve;
            _host.Start();

            base.OnStartup(e);
            var main = new MainWindow();
            var sub = new SubWindow();
            main.Show();
            sub.Show();
        }
    }
}
