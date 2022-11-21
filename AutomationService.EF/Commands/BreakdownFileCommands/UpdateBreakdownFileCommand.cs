using AutomationService.Domain.Commands.BreakdownFileCommands;
using AutomationService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Commands.BreakdownFileCommands
{
    public class UpdateBreakdownFileCommand : IUpdateBreakdownFileCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public UpdateBreakdownFileCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task UpdateBreakdownFile(BreakdownFile breakdownFile)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                var breakdownFileUpdate = await context.BreadownFiles.FirstOrDefaultAsync(f => f.Id == breakdownFile.Id);

                breakdownFileUpdate.FileName = breakdownFile.FileName;
                breakdownFileUpdate.Path = breakdownFile.Path;

                await context.SaveChangesAsync();
            }

        }
    }
}
