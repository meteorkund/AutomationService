using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands.ComboBoxItemsCommand
{
    public class LoadComboBoxItemsCommand : CommandBase
    {
        readonly BreakdownSolverStore _breakdownSolverStore;
        readonly DepartmentStore  _departmentStore;
        readonly SectorStore _sectorStore;
        readonly EmployeeStore _employeeStore;
        readonly CustomerStore _customerStore;

        public LoadComboBoxItemsCommand(BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, CustomerStore customerStore)
        {
            _breakdownSolverStore = breakdownSolverStore;
            _departmentStore = departmentStore;
            _sectorStore = sectorStore;
            _employeeStore = employeeStore;
            _customerStore = customerStore;
        }

        public override async void Execute(object? parameter)
        {
            try
            {
                await _breakdownSolverStore.LoadBreakdownSolvers();
                await _departmentStore.LoadDepartments();
                await _sectorStore.LoadSectors(); 
                await _employeeStore.LoadEmployees();
                await _customerStore.LoadCustomers();
            }
            catch
            {
            }
        }
    }
}
