using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels
{
    public class CustomerListingViewModel : ViewModelBase
    {
        readonly SelectedCustomerStore _selectedCustomerStore;
        readonly ObservableCollection<CustomerListingItemViewModel> _customerListingItemViewModels;
        readonly CustomerStore _customerStore;
        readonly ModalNavigationStore _modalNavigationStore;

        public IEnumerable<CustomerListingItemViewModel> CustomerListingItemViewModels => _customerListingItemViewModels;

        public CustomerListingItemViewModel SelectedCustomerListingItemViewModel
        {
            get
            {
                return _customerListingItemViewModels
                    .FirstOrDefault(e => e.Customer?.Id == _selectedCustomerStore.SelectedCustomer?.Id);
            }
            set
            {

                _selectedCustomerStore.SelectedCustomer = value?.Customer;
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }
        public bool HasErrorMessage => !string.IsNullOrWhiteSpace(ErrorMessage);


        public ICommand LoadCustomersCommand { get; }
        public CustomerListingViewModel(CustomerStore employeeStore, SelectedCustomerStore selectedCustomerStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedCustomerStore = selectedCustomerStore;
            _modalNavigationStore = modalNavigationStore;
            _customerStore = employeeStore;
            _customerListingItemViewModels = new ObservableCollection<CustomerListingItemViewModel>();

            LoadCustomersCommand = new LoadCustomersCommand(this, employeeStore);

            _customerStore.CustomersLoaded += CustomerStore_CustomersLoaded;
            _customerStore.CustomerAdded += CustomerStore_CustomerAdded;
            _customerStore.CustomerUpdated += CustomerStore_CustomerUpdated;
            _customerStore.CustomerDeleted += CustomerStore_CustomerDeleted;
        }

        public static CustomerListingViewModel LoadViewModel(CustomerStore employeeStore, SelectedCustomerStore selectedCustomerStore, ModalNavigationStore modalNavigationStore)
        {
            CustomerListingViewModel viewModel = new CustomerListingViewModel(employeeStore, selectedCustomerStore, modalNavigationStore);

            viewModel.LoadCustomersCommand.Execute(null);

            return viewModel;
        }


        protected override void Dispose()
        {
            _customerStore.CustomersLoaded -= CustomerStore_CustomersLoaded;
            _customerStore.CustomerAdded -= CustomerStore_CustomerAdded;
            _customerStore.CustomerUpdated -= CustomerStore_CustomerUpdated;
            _customerStore.CustomerDeleted -= CustomerStore_CustomerDeleted;

            base.Dispose();
        }


        private void CustomerStore_CustomersLoaded()
        {
            _customerListingItemViewModels.Clear();
            foreach (Customer employee in _customerStore.Customers)
            {
                AddCustomer(employee);
            }
        }
        private void CustomerStore_CustomerAdded(Customer employee)
        {
            AddCustomer(employee);
        }

        private void CustomerStore_CustomerUpdated(Customer employee)
        {
            CustomerListingItemViewModel employeeViewModel = _customerListingItemViewModels.FirstOrDefault(e => e.Customer.Id == employee.Id);

            if (employeeViewModel != null)
                employeeViewModel.Update(employee);
        }


        private void CustomerStore_CustomerDeleted(int id)
        {
            CustomerListingItemViewModel itemViewModel = _customerListingItemViewModels.FirstOrDefault(e => e.Customer?.Id == id);

            if (itemViewModel != null)
                _customerListingItemViewModels.Remove(itemViewModel);

        }



        private void AddCustomer(Customer employee)
        {
            CustomerListingItemViewModel itemViewModel = new CustomerListingItemViewModel(employee, _customerStore, _modalNavigationStore);
            _customerListingItemViewModels.Add(itemViewModel);
        }
    }
}
