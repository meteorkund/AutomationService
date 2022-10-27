using AutomationService.Domain.Commands;
using AutomationService.Domain.Queries;
using AutomationService.EF.Commands;
using AutomationService.EF.Queries;
using AutomationService.WPF.HostBuilders;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
               .AddDbContext()
               .ConfigureServices((context, services) =>
               {

                   services.AddSingleton<IGetAllCustomersQuery, GetAllCustomersQuery>();
                   services.AddSingleton<ICreateCustomerCommand, CreateCustomerCommand>();
                   services.AddSingleton<IUpdateCustomerCommand, UpdateCustomerCommand>();
                   services.AddSingleton<IDeleteCustomerCommand, DeleteCustomerCommand>();

                   services.AddSingleton<ModalNavigationStore>();
                   services.AddSingleton<CustomerStore>();
                   services.AddSingleton<SelectedCustomerStore>();

                   services.AddTransient<CustomersViewModel>();
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

            _host.Start();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
