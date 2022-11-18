using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.BreakdownSolverQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class BreakdownSolverStore
    {
        readonly IGetAllBreakdownSolverQuery _getAllBreakdownSolver;

        readonly List<BreakdownSolver> _breakdownSolvers;
        public IEnumerable<BreakdownSolver> BreakdownSolvers => _breakdownSolvers;

        public event Action<BreakdownSolver> BreakdownSolversLoaded;

        public BreakdownSolverStore(IGetAllBreakdownSolverQuery getAllBreakdownSolver)
        {
            _getAllBreakdownSolver = getAllBreakdownSolver;
            _breakdownSolvers = new List<BreakdownSolver>();
        }

        public async Task LoadBreakdownSolvers()
        {
            IEnumerable<BreakdownSolver> breakdownSolvers = await _getAllBreakdownSolver.GetAllAllBreakdownSolvers();

            var breakdownSolversSorted = breakdownSolvers.OrderBy(s => s.NameSurname).ToList();

            _breakdownSolvers.Clear();

            _breakdownSolvers.AddRange(breakdownSolversSorted);
        }
    }
}
