using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands.ComboBoxItemsCommand
{
    public class LoadComboBoxItemsCommand : CommandBase
    {
        readonly BreakdownSolverStore _breakdownSolverStore;

        public LoadComboBoxItemsCommand(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, BreakdownSolverStore breakdownSolverStore)
        {
            _breakdownSolverStore = breakdownSolverStore;
        }

        public override async void Execute(object? parameter)
        {
            try
            {
                await _breakdownSolverStore.LoadBreakdownSolvers();
            }
            catch
            {
                MessageBox.Show("PERSONELLER YÜKLENİRKEN HATAYLA KARŞILAŞILDI!");
            }
        }
    }
}
