using AutomationService.EF;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels
{
    public class AddBreakdownViewModel : ViewModelBase
    {
        public BreakdownDetailsFormViewModel BreakdownDetailsFormViewModel { get; }

        public AddBreakdownViewModel(BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            ICommand submitCommand = new AddBreakdownCommand(this, breakdownStore, modalNavigationStore, contextFactory);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BreakdownDetailsFormViewModel = new BreakdownDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
