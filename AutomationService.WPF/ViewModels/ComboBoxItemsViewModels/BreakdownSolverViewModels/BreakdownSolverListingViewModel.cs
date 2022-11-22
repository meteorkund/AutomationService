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
        readonly BreakdownSolverStore _breakdownSolverStore;
        public IEnumerable<BreakdownSolverListingItemViewModel> BreakdownSolverListingItemViewModels => _breakdownSolverStore._breakdownSolverListingItemViewModels;

        public BreakdownSolverListingViewModel(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, BreakdownSolverStore breakdownSolverStore)
        {
            _breakdownSolverStore = breakdownSolverStore;
        }


    }
}
