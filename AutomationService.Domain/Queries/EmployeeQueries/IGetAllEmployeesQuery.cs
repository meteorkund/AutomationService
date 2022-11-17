using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Queries.EmployeeQueries;

public interface IGetAllEmployeesQuery
{
    Task<IEnumerable<Employee>> GetAllEmployees();
}

