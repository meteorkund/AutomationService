using AutomationService.Domain.Commands.BreakdownCommands;
using AutomationService.Domain.Models;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Commands.BreakdownCommands
{
    public class CreateBreakdownCommand : ICreateBreakdownCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public CreateBreakdownCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Create(Breakdown breakdown)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                BreakdownDTO breakdownDTO = new BreakdownDTO()
                {
                    Status = true,

                    DepartmentId = breakdown.Department.Id,
                    SectorId = breakdown.Sector.Id,
                    EmployeeId = breakdown.Employee.Id,
                    CustomerId = breakdown.Customer.Id,
                    BreakdownSolverId= breakdown.BreakdownSolver.Id,

                    IsElectrical = breakdown.IsElectrical,
                    IsMechanical = breakdown.IsMechanical,

                    Cause = breakdown.Cause,
                    Service = breakdown.Service,

                };

                context.Breakdowns.Add(breakdownDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
