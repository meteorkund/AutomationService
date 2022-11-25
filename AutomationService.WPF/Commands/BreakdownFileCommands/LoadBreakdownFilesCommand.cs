using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownFileViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands.BreakdownFileCommands
{
    public class LoadBreakdownFilesCommand : CommandBase
    {
        readonly BreakdownFileStore _breakdownFileStore;

        public LoadBreakdownFilesCommand(BreakdownFileListingViewModel breakdownFileListingViewModel, BreakdownFileStore breakdownFileStore)
        {
            _breakdownFileStore = breakdownFileStore;
        }

        public override async void Execute(object? parameter)
        {
            try
            {
                await _breakdownFileStore.LoadBreakdownFiles();
            }
            catch
            {
            }
        }
    }
}
