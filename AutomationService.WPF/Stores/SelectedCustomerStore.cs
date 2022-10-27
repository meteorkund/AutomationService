using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class SelectedCustomerStore
    {
        readonly CustomerStore _customerStore;
        private Customer _selectedCustomer;

        public SelectedCustomerStore(CustomerStore customerStore)
        {
            _customerStore = customerStore;

            _customerStore.CustomerUpdated += EmployeeStore_EmployeeUpdated;
        }

        private void EmployeeStore_EmployeeUpdated(Customer customer)
        {
            if (customer.Id == SelectedCustomer?.Id)
                SelectedCustomer = customer;
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                SelectedCustomerChanged?.Invoke();
            }
        }
        public event Action SelectedCustomerChanged;

    }
}
