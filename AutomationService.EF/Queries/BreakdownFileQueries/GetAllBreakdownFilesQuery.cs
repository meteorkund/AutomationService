using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.BreakdownFileQueries;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Queries.BreakdownFileQueries
{
    public class GetAllBreakdownFilesQuery : IGetAllBreakdownFilesQuery
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public GetAllBreakdownFilesQuery(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<BreakdownFile>> GetAllBreakdownFiles()
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                IEnumerable<BreadownFileDTO> breadownFileDTOs = await context.BreadownFiles.ToListAsync();

                return breadownFileDTOs.Select(e => new BreakdownFile
                {
                    Id = e.Id,
                    BreakdownId = e.BreakdownId,
                    FileName = e.FileName,
                    FileExtension = e.FileExtension,
                    Path = e.Path,
                });



            }
        }
    }
}

