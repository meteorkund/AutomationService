using AutomationService.EF;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class AddBreakdownViewModel : ViewModelBase
    {
        public BreakdownDetailsFormViewModel BreakdownDetailsFormViewModel { get; }

        public AddBreakdownViewModel(BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory, BreakdownSolverStore breakdownSolverStore)
        {
            ICommand submitCommand = new AddBreakdownCommand(this, breakdownStore, modalNavigationStore, contextFactory);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BreakdownDetailsFormViewModel = BreakdownDetailsFormViewModel.LoadComboboxItems(submitCommand, cancelCommand, breakdownSolverStore);
        }
    }
}
