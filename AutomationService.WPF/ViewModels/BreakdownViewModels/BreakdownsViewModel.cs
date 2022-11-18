using AutomationService.EF;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class BreakdownsViewModel : ViewModelBase
    {
        public BreakdownListingViewModel BreakdownListingViewModel { get; }
        public BreakdownDetailsViewModel BreakdownDetailsViewModel { get; }

        readonly AutomationServiceDBContextFactory _contextFactory;


        public TopMenuViewModel TopMenuViewModel { get; }
        public LeftMenuViewModel LeftMenuViewModel { get; }
        public BreakdownsViewModel(BreakdownStore breakdownStore, SelectedBreakdownStore selectedBreakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory, BreakdownFileStore breakdownFileStore, SelectedBreakdownFileStore selectedBreakdownFileStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore)
        {
            _contextFactory = contextFactory;

            BreakdownListingViewModel = BreakdownListingViewModel.LoadViewModel(breakdownStore, selectedBreakdownStore, modalNavigationStore, breakdownSolverStore, departmentStore, sectorStore, employeeStore);
            BreakdownDetailsViewModel = new BreakdownDetailsViewModel(selectedBreakdownStore, breakdownFileStore, selectedBreakdownFileStore);

            TopMenuViewModel = new TopMenuViewModel(breakdownStore, modalNavigationStore, contextFactory, breakdownSolverStore, departmentStore, sectorStore, employeeStore);
            LeftMenuViewModel = new LeftMenuViewModel();

        }
    }
}
