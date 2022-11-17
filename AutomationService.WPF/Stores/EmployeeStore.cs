using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.EmployeeQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class EmployeeStore
    {
        readonly IGetAllEmployeesQuery _getAllEmployees;
        readonly List<Employee> _employees;

        public IEnumerable<Employee> Employees => _employees;

        public event Action EmployeesLoaded;

        public EmployeeStore(IGetAllEmployeesQuery getAllEmployees)
        {
            _getAllEmployees = getAllEmployees;
            _employees = new List<Employee>();
        }

        public async Task LoadEmployees()
        {
            IEnumerable<Employee> employees = await _getAllEmployees.GetAllEmployees();

            _employees.Clear();

            IEnumerable<Employee> sortedEmployees = employees.OrderBy(e => e.NameSurname).ToList();

            _employees.AddRange(sortedEmployees);

            EmployeesLoaded?.Invoke();
        }
    }
}
