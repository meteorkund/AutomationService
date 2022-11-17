using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.EmployeeQueries;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Queries.EmployeeQueries
{
    public class GetAllEmployeesQuery : IGetAllEmployeesQuery
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public GetAllEmployeesQuery(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                IEnumerable<EmployeeDTO> employeeDTOs = await context.Employees.ToListAsync();

                return employeeDTOs.Select(e => new Employee
                {
                    Id = e.Id,
                    NameSurname = e.NameSurname
                });
            }
        }
    }
}
