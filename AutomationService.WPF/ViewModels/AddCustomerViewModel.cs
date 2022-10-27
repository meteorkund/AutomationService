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
    public class AddCustomerViewModel : ViewModelBase
    {
        public CustomerDetailsFormViewModel CustomerDetailsFormViewModel { get; }

        public AddCustomerViewModel(CustomerStore customerStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            ICommand submitCommand = new AddCustomerCommand(this, customerStore, modalNavigationStore, contextFactory);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            CustomerDetailsFormViewModel = new CustomerDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
