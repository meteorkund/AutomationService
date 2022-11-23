using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.CustomerViewModels;

public class CustomerListingViewModel : ViewModelBase
{
    readonly CustomerStore _customerStore;
    public IEnumerable<CustomerListingItemViewModel> CustomerListingItemViewModels => _customerStore._customerListingItemViewModels;

    public CustomerListingViewModel(CustomerStore customerStore)
    {
        _customerStore = customerStore;
    }


}
