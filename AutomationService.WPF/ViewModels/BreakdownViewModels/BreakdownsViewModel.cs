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
        public BreakdownsViewModel(BreakdownStore employeeStore, SelectedBreakdownStore selectedBreakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory, BreakdownFileStore breakdownFileStore, SelectedBreakdownFileStore selectedBreakdownFileStore)
        {
            _contextFactory = contextFactory;

            BreakdownListingViewModel = BreakdownListingViewModel.LoadViewModel(employeeStore, selectedBreakdownStore, modalNavigationStore);
            BreakdownDetailsViewModel = new BreakdownDetailsViewModel(selectedBreakdownStore, breakdownFileStore, selectedBreakdownFileStore);

            TopMenuViewModel = new TopMenuViewModel(employeeStore, modalNavigationStore, contextFactory);
            LeftMenuViewModel = new LeftMenuViewModel();

        }
    }
}
