
using Microsoft.EntityFrameworkCore;
using AutomationService.Domain.Queries;
using AutomationService.Domain.Models.Common;
using AutomationService.EF.DTOs;

namespace AutomationService.EF.Queries;

public class GetAllDepartmentsQuery : IGetAllDepartmentsQuery
{
    readonly AutomationServiceDBContextFactory _contextFactory;

    public GetAllDepartmentsQuery(AutomationServiceDBContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        using (AutomationServiceDBContext context = _contextFactory.Create())
        {
            IEnumerable<DepartmentDTO> departmentDTOs = await context.Departments.ToListAsync();
            return departmentDTOs.Select(d => new Department(
                d.Id,
                d.DepartmentName
                ));
        }
    }
}
