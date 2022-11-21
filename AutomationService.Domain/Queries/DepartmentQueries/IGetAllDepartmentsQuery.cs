using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Queries;

public interface IGetAllDepartmentsQuery
{
    Task<IEnumerable<Department>> GetAllDepartments();
}
