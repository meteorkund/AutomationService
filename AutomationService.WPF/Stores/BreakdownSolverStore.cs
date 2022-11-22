using AutomationService.Domain.Models.Common;
using AutomationService.Domain.Queries.BreakdownSolverQueries;
using AutomationService.WPF.ViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.BreakdownSolverViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class BreakdownSolverStore : ViewModelBase
    {
        readonly IGetAllBreakdownSolverQuery _getAllBreakdownSolver;

        readonly List<BreakdownSolver> _breakdownSolvers;
        public IEnumerable<BreakdownSolver> BreakdownSolvers => _breakdownSolvers;
        public ObservableCollection<BreakdownSolverListingItemViewModel> _breakdownSolverListingItemViewModels;

        public event Action BreakdownSolversLoaded;

        public BreakdownSolverStore(IGetAllBreakdownSolverQuery getAllBreakdownSolver)
        {
            _getAllBreakdownSolver = getAllBreakdownSolver;
            _breakdownSolvers = new List<BreakdownSolver>();

            _breakdownSolverListingItemViewModels = new ObservableCollection<BreakdownSolverListingItemViewModel>();

            BreakdownSolversLoaded += BreakdownSolverStore_BreakdownSolversLoaded;
        }

        public async Task LoadBreakdownSolvers()
        {
            IEnumerable<BreakdownSolver> breakdownSolvers = await _getAllBreakdownSolver.GetAllAllBreakdownSolvers();

            var breakdownSolversSorted = breakdownSolvers.OrderBy(s => s.NameSurname).ToList();

            _breakdownSolvers.Clear();

            _breakdownSolvers.AddRange(breakdownSolversSorted);

            BreakdownSolversLoaded?.Invoke();
        }

        private void BreakdownSolverStore_BreakdownSolversLoaded()
        {
            _breakdownSolverListingItemViewModels.Clear();
            foreach (BreakdownSolver breakdownSolver in BreakdownSolvers)
            {
                AddBreakdownSolver(breakdownSolver);
            }
        }

        private void AddBreakdownSolver(BreakdownSolver breakdownSolver)
        {
            BreakdownSolverListingItemViewModel itemViewModel = new BreakdownSolverListingItemViewModel(breakdownSolver);

            _breakdownSolverListingItemViewModels.Add(itemViewModel);
        }

        protected override void Dispose()
        {
            BreakdownSolversLoaded -= BreakdownSolverStore_BreakdownSolversLoaded;

            base.Dispose();
        }
    }
}
