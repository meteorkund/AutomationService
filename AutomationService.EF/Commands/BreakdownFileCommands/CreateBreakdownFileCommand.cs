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
    public class CreateBreakdownFileCommand : ICreateBreakdownFileCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public CreateBreakdownFileCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateBreakdownFile(BreakdownFile breakdownFile)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                BreakdownFileDTO breakdownDTO = new BreakdownFileDTO()
                {
                    Id= breakdownFile.Id,
                    FileName = breakdownFile.FileName,
                    FileExtension = breakdownFile.FileExtension,
                    Path = breakdownFile.Path,
                    BreakdownId = breakdownFile.BreakdownId,
                };

                context.BreadownFiles.Add(breakdownDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
