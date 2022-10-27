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
        public ICommand AddCustomerCommand { get; }
        readonly AutomationServiceDBContextFactory _contextFactory;

        public TopMenuViewModel(CustomerStore customerStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            AddCustomerCommand = new OpenAddCustomerCommand(customerStore, modalNavigationStore, contextFactory);
        }
    }
}
