using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands
{
    public class DeleteBreadownCommand : AsyncCommandBase
    {

        readonly BreakdownStore _breakdownStore;
        readonly BreakdownListingItemViewModel _breakdownListingItemViewModel;

        public DeleteBreadownCommand(BreakdownListingItemViewModel customerListingItemViewModel, BreakdownStore breakdownStore)
        {
            _breakdownListingItemViewModel = customerListingItemViewModel;
            _breakdownStore = breakdownStore;

        }

        public override async Task ExecuteAsync(object? parameter)
        {
            string message = "Arıza kaydını silmek istediğinize emin misiniz";
            string caption = "Dikkat!";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                _breakdownListingItemViewModel.IsDeleting = true;

                Breakdown breakdown = _breakdownListingItemViewModel.Breakdown;

                try
                {
                    await _breakdownStore.Delete(breakdown.Id);

                }
                catch (Exception)
                {
                    MessageBox.Show("Personel silinirken hatayla karşılaşıldı!", "Hata!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    _breakdownListingItemViewModel.IsDeleting = false;

                }

            }


        }
    }
}
