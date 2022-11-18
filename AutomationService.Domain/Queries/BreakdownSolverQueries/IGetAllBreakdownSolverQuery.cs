using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Queries.BreakdownSolverQueries
{
    public interface IGetAllBreakdownSolverQuery
    {
        Task<IEnumerable<BreakdownSolver>> GetAllAllBreakdownSolvers();
    }
}
