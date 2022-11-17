using AutomationService.WPF.Stores;
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
        readonly SelectedBreakdownFileStore _selectedBreakdownFileStore;
        public OpenBreakdownFileCommand(SelectedBreakdownFileStore selectedBreakdownFileStore)
        {
            _selectedBreakdownFileStore= selectedBreakdownFileStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {              
                
                MessageBox.Show(_selectedBreakdownFileStore.SelectedBreakdownFile?.FileName);
                //Process.Start(filePath);
            }
            catch
            {
                MessageBox.Show("DOSYA BULUNAMADI!");
            }
        }
    }
}
