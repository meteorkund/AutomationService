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
        public string CompanyName { get; }
        public string Country { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public CustomerListingItemViewModel(string company, string country)
        {
            CompanyName = company;
            Country = country;
        }
    }
}
