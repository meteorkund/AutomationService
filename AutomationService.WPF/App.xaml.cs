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
           .AddViewModels()
           .AddStores()
           .AddQueries()
           .AddCommands()
           .ConfigureServices((context, services) =>
           {
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
            if (AppControl.DateTimeResponse("18.03.2023"))
            {
                MessageBox.Show("YAZILIM DESTEK SÜRESİ DOLMUŞTUR.","HATA",MessageBoxButton.OK,MessageBoxImage.Error);
                Current.Shutdown();
            }
            else
            {
            _host.Start();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
            }
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}
