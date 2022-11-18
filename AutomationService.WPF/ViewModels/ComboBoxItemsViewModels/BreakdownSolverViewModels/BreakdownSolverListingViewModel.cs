using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Commands.ComboBoxItemsCommand;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.BreakdownSolverViewModels
{
    public class BreakdownSolverListingViewModel : ViewModelBase
    {
        readonly ObservableCollection<BreakdownSolverListingItemViewModel> _breakdownSolverListingItemViewModels;
        readonly BreakdownSolverStore _breakdownSolverStore;
        public IEnumerable<BreakdownSolverListingItemViewModel> BreakdownSolverListingItemViewModels => _breakdownSolverListingItemViewModels;

        public BreakdownSolverListingViewModel(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, BreakdownSolverStore breakdownSolverStore)
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

        protected override void Dispose()
        {
            base.Dispose();
        }
    }
}
