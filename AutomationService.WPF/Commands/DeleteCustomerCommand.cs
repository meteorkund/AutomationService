using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands
{
    public class DeleteCustomerCommand : AsyncCommandBase
    {

        readonly CustomerStore _customerStore;
        readonly CustomerListingItemViewModel _customerListingItemViewModel;

        public DeleteCustomerCommand(CustomerListingItemViewModel customerListingItemViewModel, CustomerStore customerStore)
        {
            _customerListingItemViewModel = customerListingItemViewModel;
            _customerStore = customerStore;

        }

        public override async Task ExecuteAsync(object? parameter)
        {
            string message = "Personeli silmek istediğinize emin misiniz";
            string caption = "Dikkat!";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                _customerListingItemViewModel.IsDeleting = true;

                Customer customer = _customerListingItemViewModel.Customer;

                try
                {
                    await _customerStore.Delete(customer.Id);

                }
                catch (Exception)
                {
                    MessageBox.Show("Personel silinirken hatayla karşılaşıldı!", "Hata!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    _customerListingItemViewModel.IsDeleting = false;

                }

            }


        }
    }
}
