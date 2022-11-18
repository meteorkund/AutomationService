using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands
{
    public class OpenEditBreakdownCommand : CommandBase
    {
        readonly BreakdownStore _breakdownStore;
        readonly BreakdownSolverStore _breakdownSolverStore;

        readonly ModalNavigationStore _modalNavigationStore;
        readonly BreakdownListingItemViewModel _breakdownListingItemViewModel;

        public OpenEditBreakdownCommand(BreakdownListingItemViewModel employeeListingItemViewModel, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore)
        {
            _breakdownListingItemViewModel = employeeListingItemViewModel;
            _breakdownStore = breakdownStore;
            _modalNavigationStore = modalNavigationStore;

        }

        public override void Execute(object? parameter)
        {
            Breakdown breakdown = _breakdownListingItemViewModel.Breakdown;

            EditBreakdownViewModel editCustomerViewModel = new EditBreakdownViewModel(breakdown, _breakdownStore, _modalNavigationStore,_breakdownSolverStore);
            _modalNavigationStore.CurrentViewModel = editCustomerViewModel;
        }
    }
}
