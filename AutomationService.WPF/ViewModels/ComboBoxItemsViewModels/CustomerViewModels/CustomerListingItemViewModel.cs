using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.CustomerViewModels
{
    public class CustomerListingItemViewModel
    {
        public Customer Customer { get; private set; }

        public int CustomerId => Customer.Id;
        public string CompanyName => Customer.CompanyName;
        public string Country => Customer.Country;

        public CustomerListingItemViewModel(Customer customer)
        {
            Customer = customer;
        }
    }
}
