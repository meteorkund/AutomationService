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
        readonly DepartmentStore _departmentStore;
        readonly SectorStore _sectorStore;
        readonly EmployeeStore _employeeStore;
        readonly CustomerStore _customerStore;

        readonly AutomationServiceDBContextFactory _contextFactory;

        public OpenAddBreakdownCommand(BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, CustomerStore customerStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _contextFactory = contextFactory;

            _breakdownStore = breakdownStore;
            _breakdownSolverStore = breakdownSolverStore;
            _departmentStore = departmentStore;
            _sectorStore = sectorStore;
            _employeeStore = employeeStore;
            _customerStore = customerStore;
        }

        public override void Execute(object? parameter)
        {
            AddBreakdownViewModel addBreakdownViewModel = new AddBreakdownViewModel(_breakdownStore, _modalNavigationStore, _contextFactory, _breakdownSolverStore, _departmentStore, _sectorStore, _employeeStore, _customerStore);

            _modalNavigationStore.CurrentViewModel = addBreakdownViewModel;
        }
    }
}
