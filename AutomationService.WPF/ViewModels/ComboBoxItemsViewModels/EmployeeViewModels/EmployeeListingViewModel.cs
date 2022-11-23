using AutomationService.Domain.Models;
using AutomationService.WPF.Commands.EmployeeCommands;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.EmployeeViewModels
{
    public class EmployeeListingViewModel : ViewModelBase
    {
        readonly EmployeeStore _employeeStore;
        public IEnumerable<EmployeeListingItemViewModel> EmployeeListingItemViewModels => _employeeStore._employeeListingItemViewModels;


        public EmployeeListingViewModel(EmployeeStore employeeStore)
        {
            _employeeStore = employeeStore;
        }


    }
}
