using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.EmployeeViewModels
{
    public class EmployeeListingItemViewModel : ViewModelBase
    {
        public Employee Employee { get; private set; }

        public int EmployeeId => Employee.Id;
        public string NameSurname => Employee.NameSurname;

        public EmployeeListingItemViewModel(Employee employee)
        {
            Employee = employee;
        }

    }
}
