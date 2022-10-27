using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands
{
    public class EditCustomerCommand : AsyncCommandBase
    {
        readonly EditCustomerViewModel _editCustomerViewModel;
        readonly ModalNavigationStore _modalNavigationStore;
        readonly CustomerStore _customerStore;

        public EditCustomerCommand(EditCustomerViewModel editCustomerViewModel, CustomerStore customerStore, ModalNavigationStore modalNavigationStore)
        {
            _editCustomerViewModel = editCustomerViewModel;
            _customerStore = customerStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            CustomerDetailsFormViewModel formViewModel = _editCustomerViewModel.CustomerDetailsFormViewModel;

            formViewModel.ErrorMessage = null;
            //formViewModel.IsSubmitting = true;


            Customer customer = new Customer(
                "COMPANY NAME",
                "COUNTRY",
                new Breakdown
                {
                    Status = true,
                    IsElectrical = false,
                    IsMechanical = false
                },
                new Employee
                {
                    NameSurname = "ORKUN"
                }
                );

            try
            {
                await _customerStore.Update(customer);

            }
            catch (Exception)
            {
                formViewModel.ErrorMessage = "Personel güncelleme sırasında hata oluştu. Daha sonra tekrar deneyiniz.";
            }
            finally
            {
                //formViewModel.IsSubmitting = false;
            }
        }
    }
}
