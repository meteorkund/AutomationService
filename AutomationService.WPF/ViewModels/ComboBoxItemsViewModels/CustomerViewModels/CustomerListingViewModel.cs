using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.CustomerViewModels
{
    public class CustomerListingViewModel : ViewModelBase
    {
        readonly ObservableCollection<CustomerListingItemViewModel> _customerListingItemViewModels;
        readonly CustomerStore _customerStore;

        public IEnumerable<CustomerListingItemViewModel> CustomerListingItemViewModels => _customerListingItemViewModels.

        public CustomerListingViewModel(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, CustomerStore customerStore)
        {
            _customerStore = customerStore;
            _customerListingItemViewModels = new ObservableCollection<CustomerListingItemViewModel>();

            CustomerStore_CustomerStoreLoaded();
        }

        private void CustomerStore_CustomerStoreLoaded()
        {
            _customerListingItemViewModels.Clear();
            foreach (Customer customer in _customerStore.Customers)
            {
                AddCustomer(customer);
            }
        }

        private void AddCustomer(Customer customer)
        {
            CustomerListingItemViewModel itemViewModel = new CustomerListingItemViewModel(customer);

            _customerListingItemViewModels.Add(itemViewModel);
        }
    }
}
