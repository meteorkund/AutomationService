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
        readonly SectorStore _sectorStore;
        public IEnumerable<SectorListingItemViewModel> SectorListingItemViewModels => _sectorStore._sectorListingItemViewModels;

        public SectorListingViewModel(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, SectorStore sectorStore)
        {
            _sectorStore = sectorStore;

        }

    }
}

