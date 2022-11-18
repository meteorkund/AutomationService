using AutomationService.EF;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands
{
    public class OpenAddBreakdownCommand : CommandBase
    {
        readonly ModalNavigationStore _modalNavigationStore;
        readonly BreakdownStore _breakdownStore;
        readonly BreakdownSolverStore _breakdownSolverStore;
        readonly AutomationServiceDBContextFactory _contextFactory;

        public OpenAddBreakdownCommand(BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory, BreakdownSolverStore breakdownSolverStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _contextFactory = contextFactory;

            _breakdownStore = breakdownStore;
            _breakdownSolverStore = breakdownSolverStore;
        }

        public override void Execute(object? parameter)
        {
            AddBreakdownViewModel addBreakdownViewModel = new AddBreakdownViewModel(_breakdownStore, _modalNavigationStore, _contextFactory, _breakdownSolverStore);

            _modalNavigationStore.CurrentViewModel = addBreakdownViewModel;
        }
    }
}
