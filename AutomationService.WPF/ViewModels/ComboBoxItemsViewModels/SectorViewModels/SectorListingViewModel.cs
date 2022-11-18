using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.SectorViewModels
{
    public class SectorListingViewModel : ViewModelBase
    {
        readonly ObservableCollection<SectorListingItemViewModel> _sectorListingItemViewModel;
        readonly SectorStore _sectorStore;
        public IEnumerable<SectorListingItemViewModel> SectorListingItemViewModels => _sectorListingItemViewModel;

        public SectorListingViewModel(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, SectorStore sectorStore)
        {
            _sectorStore = sectorStore;
            _sectorListingItemViewModel = new ObservableCollection<SectorListingItemViewModel>();
            SectorStore_SectorsLoaded();
        }

        private void SectorStore_SectorsLoaded()
        {
            _sectorListingItemViewModel.Clear();
            foreach (Sector sector in _sectorStore.Sectors)
            {
                AddBreakdownSolver(sector);
            }
        }

        private void AddBreakdownSolver(Sector sector)
        {
            SectorListingItemViewModel itemViewModel = new SectorListingItemViewModel(sector);

            _sectorListingItemViewModel.Add(itemViewModel);
        }

        protected override void Dispose()
        {
            base.Dispose();
        }
    }
}

