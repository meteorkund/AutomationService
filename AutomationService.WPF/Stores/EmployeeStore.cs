using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.EmployeeQueries;
using AutomationService.WPF.ViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class EmployeeStore : ViewModelBase
    {
        readonly IGetAllEmployeesQuery _getAllEmployees;
        readonly List<Employee> _employees;

        public IEnumerable<Employee> Employees => _employees;
        public ObservableCollection<EmployeeListingItemViewModel> _employeeListingItemViewModels;

        public event Action EmployeesLoaded;

        public EmployeeStore(IGetAllEmployeesQuery getAllEmployees)
        {
            _getAllEmployees = getAllEmployees;
            _employees = new List<Employee>();

            _employeeListingItemViewModels = new ObservableCollection<EmployeeListingItemViewModel>();

            EmployeesLoaded += EmployeeStore_EmployeesLoaded;
        }

        public async Task LoadEmployees()
        {
            IEnumerable<Employee> employees = await _getAllEmployees.GetAllEmployees();

            _employees.Clear();

            IEnumerable<Employee> sortedEmployees = employees.OrderBy(e => e.NameSurname).ToList();

            _employees.AddRange(sortedEmployees);

            EmployeesLoaded?.Invoke();
        }


        private void EmployeeStore_EmployeesLoaded()
        {
            _employeeListingItemViewModels.Clear();
            foreach (Employee employee in Employees)
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
            EmployeesLoaded -= EmployeeStore_EmployeesLoaded;
            base.Dispose();
        }
    }
}
