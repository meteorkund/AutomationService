using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.BreakdownSolverViewModels
{
    public class BreakdownSolverListingItemViewModel : ViewModelBase
    {
        public BreakdownSolver BreakdownSolver { get; private set; }

        public int BreakdownSolverId => BreakdownSolver.Id;
        public string BreakdownSolverNameSurname => BreakdownSolver.NameSurname;

        public BreakdownSolverListingItemViewModel(BreakdownSolver breakdownSolver)
        {
            BreakdownSolver = breakdownSolver;
        }
    }
}
