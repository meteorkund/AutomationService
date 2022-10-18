using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels
{
    public class CustomerListingViewModel : ViewModelBase
    {
        readonly ObservableCollection<CustomerListingItemViewModel> _customerListingItemViewModels;
        public IEnumerable<CustomerListingItemViewModel> CustomerListingItemViewModels => _customerListingItemViewModels;
        public CustomerListingViewModel()
        {
            _customerListingItemViewModels = new ObservableCollection<CustomerListingItemViewModel>();

            _customerListingItemViewModels.Add(new CustomerListingItemViewModel("Demir İnşaat", "Türkiye"));
            _customerListingItemViewModels.Add(new CustomerListingItemViewModel("Yalın Elektronik", "Brezilya"));
            _customerListingItemViewModels.Add(new CustomerListingItemViewModel("Şimşek Pazarlama", "Japonya"));

        }
    }
}
