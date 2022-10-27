using AutomationService.Domain.Models;
using AutomationService.EF.DTOs;
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
    public class EditCustomerViewModel : ViewModelBase
    {
        public int CustomerId { get; }
        public CustomerDetailsFormViewModel CustomerDetailsFormViewModel { get; }

        public EditCustomerViewModel(Customer customer,CustomerStore customerStore, ModalNavigationStore modalNavigationStore)
        {
            CustomerId = customer.Id;

            ICommand submitCommand = new EditCustomerCommand(this, customerStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            CustomerDetailsFormViewModel = new CustomerDetailsFormViewModel(submitCommand, cancelCommand)
            {
                NameSurname = customer.Employee.NameSurname,
            };
        }
    }
}
