using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        public CustomerListingViewModel CustomerListingViewModel { get; }
        public CustomerDetailsViewModel CustomerDetailsViewModel { get; }
        public TopMenuViewModel TopMenuViewModel { get; }
        public LeftMenuViewModel LeftMenuViewModel { get; }
        public CustomersViewModel()
        {
            CustomerListingViewModel = new CustomerListingViewModel();
            CustomerDetailsViewModel = new CustomerDetailsViewModel();
            TopMenuViewModel = new TopMenuViewModel();
            LeftMenuViewModel = new LeftMenuViewModel();
        }
    }
}
