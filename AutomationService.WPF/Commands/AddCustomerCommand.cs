using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.EF;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands
{
    public class AddCustomerCommand : AsyncCommandBase
    {
        readonly ModalNavigationStore _modalNavigationStore;
        readonly CustomerStore _customerStore;
        readonly AddCustomerViewModel _addCustomerViewModel;
        readonly AutomationServiceDBContextFactory _contextFactory;

        int sonDosyaNo;
        public AddCustomerCommand(AddCustomerViewModel addEmployeeViewModel, CustomerStore employeeStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            _modalNavigationStore = modalNavigationStore;
            _customerStore = employeeStore;
            _addCustomerViewModel = addEmployeeViewModel;
            _contextFactory = contextFactory;

            //using (AutomationServiceDBContext context = _contextFactory.Create())
            //{
            //    var sonPersonel = context.Customers.ToList().Last();
            //    sonDosyaNo = sonPersonel.Id;
            //}
        }

        public override async Task ExecuteAsync(object parameter)
        {
            CustomerDetailsFormViewModel formViewModel = _addCustomerViewModel.CustomerDetailsFormViewModel;

            formViewModel.ErrorMessage = null;

            Customer customer = new Customer(
                "COMPANY NAME",
                "COUNTRY",
                new Breakdown
                {
                     IsElectrical = true,
                     IsMechanical = false,
                     Status = false
                },
                new Employee
                {
                    NameSurname = "Mete"
                }                
                
                );

            try
            {
                await _customerStore.Add(customer);


                _modalNavigationStore.Close();

            }
            catch (Exception)
            {
                formViewModel.ErrorMessage = "Personel kaydedilmesi sırasında hata oluştu. Daha sonra tekrar deneyiniz.";
            }
            finally
            {
                //formViewModel.IsSubmitting = false;
            }
        }
    }
}
