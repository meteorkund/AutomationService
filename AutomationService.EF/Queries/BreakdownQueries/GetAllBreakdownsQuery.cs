using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.Domain.Queries.BrekdownQueries;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Queries.BreakdownQueries
{
    public class GetAllBreakdownsQuery : IGetAllBreakdownsQuery
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public GetAllBreakdownsQuery(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Breakdown>> GetAllBreakdowns()
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                IEnumerable<BreakdownDTO> breakdownDTOs = await context.Breakdowns
                    .Include(c => c.Customer)
                    .Include(d => d.Department)
                    .Include(s => s.Sector)
                    .Include(e => e.BreakdownSolver)
                    .Include(e => e.Employee)
                    .ToListAsync();

                return breakdownDTOs.Select(e => new Breakdown
                {
                    Id = e.Id,
                    Status = e.Status,

                    IsElectrical = e.IsElectrical,
                    IsMechanical = e.IsMechanical,

                    Cause = e.Cause,
                    Service = e.Service,

                    CreatedDate = e.CreatedDate,
                    UpdatedDate = e.UpdatedDate,

                    Department = new Department(e.Department.Id, e.Department.DepartmentName),
                    Sector = new Sector(e.Sector.Id, e.Sector.SectorName),
                    Customer = new Customer(e.Customer.Id, e.Customer.CompanyName, e.Customer.Country),
                    BreakdownSolver = new BreakdownSolver(e.BreakdownSolver.Id, e.BreakdownSolver.NameSurname),
                    Employee = new Employee(e.Employee.Id, e.Employee.NameSurname)




                });



            }
        }
    }
}
