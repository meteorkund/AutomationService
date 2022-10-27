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
    internal class LoadCustomersCommand : CommandBase
    {
        readonly CustomerListingViewModel _customerListingViewModel;
        readonly CustomerStore _customerStore;


        public LoadCustomersCommand(CustomerListingViewModel customerListingViewModel, CustomerStore customerStore)
        {
            _customerListingViewModel = customerListingViewModel;
            _customerStore = customerStore;
        }

        public override async void Execute(object? parameter)
        {
            _customerListingViewModel.ErrorMessage = null;
            _customerListingViewModel.IsLoading = true;
            try
            {
                await _customerStore.Load();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _customerListingViewModel.ErrorMessage = "Personeller yüklenirken bir hatayla karşılaşıldı! \n Lütfen uygulamayı yeniden başlatın.";
            }
            finally
            {
                _customerListingViewModel.IsLoading = false;

            }
        }
    }
}
