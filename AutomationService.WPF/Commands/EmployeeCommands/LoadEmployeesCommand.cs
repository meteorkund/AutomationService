using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands.EmployeeCommands
{
    public class LoadEmployeesCommand : CommandBase
    {
        readonly EmployeeStore _employeeStore;

        public LoadEmployeesCommand(EmployeeListingViewModel employeeListingViewModel, EmployeeStore employeeStore)
        {
            _employeeStore = employeeStore;
        }

        public override async void Execute(object? parameter)
        {
            try
            {
                await _employeeStore.LoadEmployees();
            }
            catch
            {
            }
        }
    }
}
