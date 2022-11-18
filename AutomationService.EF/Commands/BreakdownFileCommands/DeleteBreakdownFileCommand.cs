using AutomationService.Domain.Commands.BreakdownFileCommands;
using AutomationService.Domain.Models;
using AutomationService.EF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Commands.BreakdownFileCommands
{
    public class DeleteBreakdownFileCommand : IDeleteBreakdownFileCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public DeleteBreakdownFileCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task DeleteBreakdownFile(int id)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                BreakdownFileDTO breakdownFileDTO = new BreakdownFileDTO()
                {
                    Id = id,
                };

                context.BreadownFiles.Remove(breakdownFileDTO);
                await context.SaveChangesAsync();

            }
        }
    }
}

