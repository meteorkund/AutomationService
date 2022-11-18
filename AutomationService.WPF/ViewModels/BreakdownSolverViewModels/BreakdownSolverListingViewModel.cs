using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.BreakdownSolverViewModels
{
    public class BreakdownSolverListingViewModel
    {
        readonly ObservableCollection<BreakdownSolverListingItemViewModel> _breakdownSolverListingItemViewModels;
        readonly BreakdownSolverStore _breakdownSolverStore;
        readonly BreakdownSolver _breakdownSolver;
        public IEnumerable<BreakdownSolverListingItemViewModel> BreakdownSolverListingItemViewModels => _breakdownSolverListingItemViewModels;

        public BreakdownSolverListingViewModel(BreakdownViewModels.BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, BreakdownSolverStore breakdownSolverStore)
        {
            _breakdownSolverStore = breakdownSolverStore;
            _breakdownSolverListingItemViewModels = new ObservableCollection<BreakdownSolverListingItemViewModel>();
            BreakdownSolverStore_BreakdownSolversLoaded();
        }

        private void BreakdownSolverStore_BreakdownSolversLoaded()
        {
            _breakdownSolverListingItemViewModels.Clear();
            foreach (BreakdownSolver breakdownSolver in _breakdownSolverStore.BreakdownSolvers)
            {
                AddBreakdownSolver(breakdownSolver);
            }
        }

        private void AddBreakdownSolver(BreakdownSolver breakdownSolver)
        {
            BreakdownSolverListingItemViewModel itemViewModel = new BreakdownSolverListingItemViewModel(breakdownSolver);

            _breakdownSolverListingItemViewModels.Add(itemViewModel);
        }
    }
}
