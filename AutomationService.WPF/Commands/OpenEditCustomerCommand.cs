using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands
{
    public class OpenEditCustomerCommand : CommandBase
    {
        readonly CustomerStore _employeeStore;
        readonly ModalNavigationStore _modalNavigationStore;
        readonly CustomerListingItemViewModel _employeeListingItemViewModel;

        public OpenEditCustomerCommand(CustomerListingItemViewModel employeeListingItemViewModel, CustomerStore employeeStore, ModalNavigationStore modalNavigationStore)
        {
            _employeeListingItemViewModel = employeeListingItemViewModel;
            _employeeStore = employeeStore;
            _modalNavigationStore = modalNavigationStore;

        }

        public override void Execute(object? parameter)
        {
            Customer employee = _employeeListingItemViewModel.Customer;

            EditCustomerViewModel editCustomerViewModel = new EditCustomerViewModel(employee, _employeeStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editCustomerViewModel;
        }
    }
}
