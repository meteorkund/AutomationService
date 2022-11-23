using AutomationService.Domain.Models;
using AutomationService.EF;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Commands.BreakdownCommands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class SolveBreakdownViewModel : ViewModelBase
    {
        private Breakdown breakdown;
        private BreakdownStore breakdownStore;
        private BreakdownSolverStore breakdownSolverStore;
        private ModalNavigationStore modalNavigationStore;

        public SolveBreakdownFormViewModel SolveBreakdownFormViewModel { get; }

        public Guid BreakdownId { get; }

        public SolveBreakdownViewModel(Breakdown breakdown, BreakdownStore breakdownStore, BreakdownSolverStore breakdownSolverStore, ModalNavigationStore modalNavigationStore)
        {
            BreakdownId = breakdown.Id;

            ICommand submitCommand = new SolveBreakdownCommand(this, breakdownStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            SolveBreakdownFormViewModel = new SolveBreakdownFormViewModel(submitCommand, cancelCommand, breakdownSolverStore, breakdown);
        }

    }
}
