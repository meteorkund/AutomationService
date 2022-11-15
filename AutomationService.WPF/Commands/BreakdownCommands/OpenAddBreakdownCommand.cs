using AutomationService.EF;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands
{
    public class OpenAddCustomerCommand : CommandBase
    {
        readonly ModalNavigationStore _modalNavigationStore;
        readonly BreakdownStore _breakdownStore;
        readonly AutomationServiceDBContextFactory _contextFactory;

        public OpenAddCustomerCommand(BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            _breakdownStore = breakdownStore;
            _modalNavigationStore = modalNavigationStore;
            _contextFactory = contextFactory;
        }

        public override void Execute(object? parameter)
        {
            AddBreakdownViewModel addBreakdownViewModel = new AddBreakdownViewModel(_breakdownStore, _modalNavigationStore, _contextFactory);

            _modalNavigationStore.CurrentViewModel = addBreakdownViewModel;
        }
    }
}
