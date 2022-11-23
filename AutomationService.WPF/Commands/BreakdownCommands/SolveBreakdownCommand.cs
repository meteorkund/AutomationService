using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands.BreakdownCommands
{
    public class SolveBreakdownCommand : AsyncCommandBase
    {
        private SolveBreakdownViewModel _solveBreakdownViewModel;
        private BreakdownStore _breakdownStore;


        public SolveBreakdownCommand(SolveBreakdownViewModel solveBreakdownViewModel, BreakdownStore breakdownStore)
        {
            _solveBreakdownViewModel = solveBreakdownViewModel;
            _breakdownStore = breakdownStore;
        }

        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
