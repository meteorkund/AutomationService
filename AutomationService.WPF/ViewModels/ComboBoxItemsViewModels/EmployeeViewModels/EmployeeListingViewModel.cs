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

        readonly ObservableCollection<EmployeeListingItemViewModel> _employeeListingItemViewModels;
        public IEnumerable<EmployeeListingItemViewModel> EmployeeListingItemViewModels => _employeeListingItemViewModels;

        public ICommand LoadEmployeesCommand { get; }

        public EmployeeListingViewModel(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, EmployeeStore employeeStore)
        {
            _employeeStore = employeeStore;

            _employeeListingItemViewModels = new ObservableCollection<EmployeeListingItemViewModel>();

            LoadEmployeesCommand = new LoadEmployeesCommand(this, employeeStore);

            EmployeeStore_EmployeesLoaded();
        }


        private void EmployeeStore_EmployeesLoaded()
        {
            _employeeListingItemViewModels.Clear();
            foreach (Employee employee in _employeeStore.Employees)
            {
                AddEmployees(employee);
            }
        }

        private void AddEmployees(Employee employee)
        {
            EmployeeListingItemViewModel itemViewModel = new EmployeeListingItemViewModel(employee);

            _employeeListingItemViewModels.Add(itemViewModel);
        }

        protected override void Dispose()
        {
            _employeeStore.EmployeesLoaded -= EmployeeStore_EmployeesLoaded;
            base.Dispose();
        }
    }
}
