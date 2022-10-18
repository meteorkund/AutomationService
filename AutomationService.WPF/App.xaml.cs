using AutomationService.WPF.ViewModels;
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
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new CustomersViewModel()
            };
            //_host.Start();

            //MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Topmost = true;
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
