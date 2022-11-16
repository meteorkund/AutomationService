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
                    IsElectrical = breakdown.IsElectrical,
                    IsMechanical = breakdown.IsMechanical,

                    Cause = breakdown.Cause,
                    Service = breakdown.Service,

                    CustomerId = breakdown.Customer.Id,

                    Department = breakdown.Department,
                    Sector = breakdown.Sector,

                };

                context.Breakdowns.Add(breakdownDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
