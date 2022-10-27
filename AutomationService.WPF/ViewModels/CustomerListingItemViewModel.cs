using AutomationService.Domain.Models;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels
{
    public class CustomerListingItemViewModel :ViewModelBase
    {
        public Customer Customer { get; private set; }
        public string CompanyName => Customer.CompanyName;
        public string Country => Customer.Country;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        private bool _isDeleting;

        public bool IsDeleting
        {
            get { return _isDeleting; }
            set
            {
                _isDeleting = value;

                OnPropertyChanged(nameof(IsDeleting));
            }
        }

        public CustomerListingItemViewModel(Customer customer, CustomerStore customerStore, ModalNavigationStore modalNavigationStore)
        {
            Customer = customer;
            EditCommand = new OpenEditCustomerCommand(this, customerStore, modalNavigationStore);
            DeleteCommand = new DeleteCustomerCommand(this, customerStore);
        }

        public void Update(Customer customer)
        {
            Customer = customer;
            OnPropertyChanged(nameof(CompanyName));
            OnPropertyChanged(nameof(Country));

        }
    }
}
