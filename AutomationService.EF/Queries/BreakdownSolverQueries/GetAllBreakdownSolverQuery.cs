using AutomationService.Domain.Models.Common;
using AutomationService.Domain.Queries.BreakdownSolverQueries;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Queries.BreakdownSolverQueries
{
    public class GetAllBreakdownSolverQuery : IGetAllBreakdownSolverQuery
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public GetAllBreakdownSolverQuery(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<BreakdownSolver>> GetAllAllBreakdownSolvers()
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                IEnumerable<BreakdownSolverDTO> breakdownSolverDTOs = await context.BreakdownSolvers.ToListAsync();
                return breakdownSolverDTOs.Select(s => new BreakdownSolver
                (
                     s.Id,
                     s.NameSurname
                ));





            }
        }
    }
}
