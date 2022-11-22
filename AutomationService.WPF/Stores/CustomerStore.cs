using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.CustomerQueries;
using AutomationService.WPF.ViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.CustomerViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class CustomerStore : ViewModelBase
    {
        readonly IGetAllCustomersQuery _getAllCustomers;
        readonly List<Customer> _customers;
        public IEnumerable<Customer> Customers => _customers;
        public ObservableCollection<CustomerListingItemViewModel> _customerListingItemViewModels;

        public event Action CustomersLoaded;

        public CustomerStore(IGetAllCustomersQuery getAllCustomers)
        {
            _getAllCustomers = getAllCustomers;
            _customers = new List<Customer>();

            _customerListingItemViewModels= new ObservableCollection<CustomerListingItemViewModel>();

            CustomersLoaded += CustomerStore_CustomerStoreLoaded;

        }

        public async Task LoadCustomers()
        {
            IEnumerable<Customer> customers = await _getAllCustomers.GetAllCustomers();

            _customers.Clear();

            _customers.AddRange(customers);

            CustomersLoaded?.Invoke();
        }

        private void CustomerStore_CustomerStoreLoaded()
        {
            _customerListingItemViewModels.Clear();
            foreach (Customer customer in Customers)
            {
                AddCustomer(customer);
            }
        }

        private void AddCustomer(Customer customer)
        {
            CustomerListingItemViewModel itemViewModel = new CustomerListingItemViewModel(customer);

            _customerListingItemViewModels.Add(itemViewModel);
        }

        protected override void Dispose()
        {
            CustomersLoaded -= CustomerStore_CustomerStoreLoaded;

            base.Dispose();
        }
    }
}
