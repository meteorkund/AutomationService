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
        readonly CustomerStore _employeeStore;
        readonly AutomationServiceDBContextFactory _contextFactory;

        public OpenAddCustomerCommand(CustomerStore customerStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            _employeeStore = customerStore;
            _modalNavigationStore = modalNavigationStore;
            _contextFactory = contextFactory;
        }

        public override void Execute(object? parameter)
        {
            AddCustomerViewModel addCustomerViewModel = new AddCustomerViewModel(_employeeStore, _modalNavigationStore, _contextFactory);

            _modalNavigationStore.CurrentViewModel = addCustomerViewModel;
        }
    }
}
