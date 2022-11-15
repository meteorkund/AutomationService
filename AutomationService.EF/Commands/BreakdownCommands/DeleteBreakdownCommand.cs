using AutomationService.Domain.Commands.BreakdownCommands;
using AutomationService.EF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Commands.BreakdownCommands
{
    public class DeleteBreakdownCommand : IDeleteBreakdownCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public DeleteBreakdownCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task DeleteBreakdown(int id)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {

                BreakdownDTO breakdownDTO = new BreakdownDTO()
                {
                    Id = id,
                };

                context.Breakdowns.Remove(breakdownDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
