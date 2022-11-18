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
        readonly DepartmentStore _departmentStore;
        readonly SectorStore _sectorStore;
        readonly EmployeeStore _employeeStore;

        readonly ModalNavigationStore _modalNavigationStore;
        readonly BreakdownListingItemViewModel _breakdownListingItemViewModel;

        public OpenEditBreakdownCommand(BreakdownListingItemViewModel employeeListingItemViewModel, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore)
        {
            _breakdownListingItemViewModel = employeeListingItemViewModel;
            _breakdownStore = breakdownStore;
            _modalNavigationStore = modalNavigationStore;

            _breakdownSolverStore= breakdownSolverStore;
            _departmentStore= departmentStore;
            _sectorStore= sectorStore;
            _employeeStore= employeeStore;

        }

        public override void Execute(object? parameter)
        {
            Breakdown breakdown = _breakdownListingItemViewModel.Breakdown;

            EditBreakdownViewModel editCustomerViewModel = new EditBreakdownViewModel(breakdown, _breakdownStore, _modalNavigationStore, _breakdownSolverStore, _departmentStore, _sectorStore, _employeeStore);
            _modalNavigationStore.CurrentViewModel = editCustomerViewModel;
        }
    }
}
