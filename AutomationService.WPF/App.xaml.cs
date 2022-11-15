using AutomationService.Domain.Commands.BreakdownCommands;
using AutomationService.Domain.Queries.BrekdownQueries;
using AutomationService.EF.Commands.BreakdownCommands;
using AutomationService.EF.Queries.BreakdownQueries;
using AutomationService.WPF.HostBuilders;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AutomationService.WPF;

public partial class App : Application
{
    readonly IHost _host;
    public App()
    {
        _host = Host.CreateDefaultBuilder()
           .AddDbContext()
           .ConfigureServices((context, services) =>
           {

               services.AddSingleton<IGetAllBreakdownsQuery, GetAllBreakdownsQuery>();
               services.AddSingleton<ICreateBreakdownCommand, CreateBreakdownCommand>();
               services.AddSingleton<IUpdateBreakdownCommand, UpdateBreakdownCommand>();
               services.AddSingleton<IDeleteBreakdownCommand, DeleteBreakdownCommand>();

               services.AddSingleton<ModalNavigationStore>();
               services.AddSingleton<BreakdownStore>();
               services.AddSingleton<SelectedBreakdownStore>();

               services.AddTransient<BreakdownsViewModel>();
               services.AddSingleton<MainViewModel>();

               services.AddSingleton<MainWindow>((services) => new MainWindow
               {
                   DataContext = services.GetRequiredService<MainViewModel>()
               });
           })
           .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        if (!AppControl.IsAppRunning("AutomationService"))
        {
            MessageBox.Show("UYGULAMA ZATEN ÇALIŞIYOR!", "HATA", MessageBoxButton.OK, MessageBoxImage.Error);
            Application.Current.Shutdown();
        }
        else
        {
            _host.Start();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}
