using AutomationService.EF;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        public CustomerListingViewModel CustomerListingViewModel { get; }
        public CustomerDetailsViewModel CustomerDetailsViewModel { get; }

        readonly AutomationServiceDBContextFactory _contextFactory;

        public ICommand LoadCustomersCommand { get; }

        public TopMenuViewModel TopMenuViewModel { get; }
        public LeftMenuViewModel LeftMenuViewModel { get; }
        public CustomersViewModel(CustomerStore employeeStore, SelectedCustomerStore selectedEmployeeStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            CustomerListingViewModel = CustomerListingViewModel.LoadViewModel(employeeStore, selectedEmployeeStore, modalNavigationStore);
            CustomerDetailsViewModel = new CustomerDetailsViewModel(selectedEmployeeStore);

            TopMenuViewModel = new TopMenuViewModel(employeeStore, modalNavigationStore, contextFactory);
            LeftMenuViewModel = new LeftMenuViewModel();

        }
    }
}
