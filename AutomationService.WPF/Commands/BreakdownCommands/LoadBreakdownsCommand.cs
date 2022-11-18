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
    internal class LoadBreakdownsCommand : CommandBase
    {
        readonly BreakdownListingViewModel _breakdownListingViewModel;
        readonly BreakdownStore _breakdownStore;


        public LoadBreakdownsCommand(BreakdownListingViewModel breakdownListingViewModel, BreakdownStore breakdownStore)
        {
            _breakdownListingViewModel = breakdownListingViewModel;
            _breakdownStore = breakdownStore;
        }


        public override async void Execute(object? parameter)
        {
            _breakdownListingViewModel.ErrorMessage = null;
            _breakdownListingViewModel.IsLoading = true;
            try
            {
                await _breakdownStore.LoadBreakdowns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _breakdownListingViewModel.ErrorMessage = "Servis kayıtları yüklenirken bir hatayla karşılaşıldı! \n Lütfen uygulamayı yeniden başlatın.";
            }
            finally
            {
                _breakdownListingViewModel.IsLoading = false;

            }
        }
    }
}
