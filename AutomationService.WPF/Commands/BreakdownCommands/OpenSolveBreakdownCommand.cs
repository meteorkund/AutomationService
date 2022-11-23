using AutomationService.Domain.Models;
using AutomationService.EF;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands.BreakdownCommands
{
    public class OpenSolveBreakdownCommand : CommandBase
    {
        readonly BreakdownDetailsViewModel _breakdownDetailsViewModel;
        readonly ModalNavigationStore _modalNavigationStore;
        readonly BreakdownSolverStore _breakdownSolverStore;
        readonly BreakdownStore _breakdownStore;


        public OpenSolveBreakdownCommand(BreakdownDetailsViewModel breakdownDetailsViewModel, BreakdownStore breakdownStore, BreakdownSolverStore breakdownSolverStore, ModalNavigationStore modalNavigationStore)
        {
            _breakdownDetailsViewModel = breakdownDetailsViewModel;
            _breakdownStore = breakdownStore;
            _breakdownSolverStore = breakdownSolverStore;
            _modalNavigationStore = modalNavigationStore;

        }

        public override void Execute(object? parameter)
        {
            Breakdown breakdown = _breakdownDetailsViewModel.SelectedBreakdown;
            SolveBreakdownViewModel solveBreakdownViewModel = new SolveBreakdownViewModel(breakdown, _breakdownStore, _breakdownSolverStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = solveBreakdownViewModel;
        }
    }
}
