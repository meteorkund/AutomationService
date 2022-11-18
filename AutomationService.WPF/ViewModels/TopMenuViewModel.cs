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
    public class TopMenuViewModel :ViewModelBase
    {
        public ICommand AddBreakdownCommand { get; }
        readonly AutomationServiceDBContextFactory _contextFactory;

        public TopMenuViewModel(BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory, BreakdownSolverStore breakdownSolverStore)
        {
            _contextFactory = contextFactory;
            AddBreakdownCommand = new OpenAddBreakdownCommand(breakdownStore, modalNavigationStore, contextFactory, breakdownSolverStore);
        }
    }
}
