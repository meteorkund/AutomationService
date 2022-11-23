using AutomationService.Domain.Commands.BreakdownCommands;
using AutomationService.Domain.Models;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Commands.BreakdownCommands
{
    public class UpdateBreakdownCommand : IUpdateBreakdownCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public UpdateBreakdownCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Update(Breakdown breakdown)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                var breakdownUpdate = await context.Breakdowns.FirstOrDefaultAsync(c => c.Id == breakdown.Id);

                breakdownUpdate.CustomerId = breakdown.CustomerId;
                breakdownUpdate.DepartmentId = breakdown.DepartmentId;
                breakdownUpdate.SectorId = breakdown.SectorId;
                breakdownUpdate.EmployeeId = breakdown.EmployeeId;

                breakdownUpdate.IsElectrical = breakdown.IsElectrical;
                breakdownUpdate.IsMechanical = breakdown.IsMechanical;
                breakdownUpdate.Cause = breakdown.Cause;
                breakdownUpdate.Service = breakdown.Service;

                if (breakdown.Status == false)                
                    breakdownUpdate.Status = false;

                if (breakdownUpdate.BreakdownSolverId == 1)
                    breakdownUpdate.SolvedDate = DateTime.Now;

                breakdownUpdate.BreakdownSolverId = breakdown.BreakdownSolverId;

                await context.SaveChangesAsync();
            }
        }
    }
}
