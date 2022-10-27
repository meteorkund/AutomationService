using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels
{
    public class LeftMenuViewModel : ViewModelBase
    {
        public static RelayCommand ExitToAppCommand { get; set; }

        public LeftMenuViewModel()
        {
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            ExitToAppCommand = new RelayCommand(ExitToApp);
        }

        private void ExitToApp()
        {
            Application.Current.Shutdown();
        }
    }
}
