using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands.BreakdownFileCommands
{
    public class OpenBreakdownFileCommand : AsyncCommandBase
    {
        string _filePath;

        public OpenBreakdownFileCommand(string filePath)
        {
            _filePath= filePath;

        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {               
                
                await Task.Delay(1000);
                MessageBox.Show(_filePath);
                //Process.Start(filePath);
            }
            catch
            {
                MessageBox.Show("DOSYA BULUNAMADI!");
            }
        }
    }
}
