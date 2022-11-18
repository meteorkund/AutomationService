using AutomationService.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.SectorViewModels
{
    public class SectorListingItemViewModel
    {
        public Sector Sector { get; private set; }

        public int SectorId => Sector.Id;
        public string SectorName => Sector.SectorName;

        public SectorListingItemViewModel(Sector sector)
        {
            Sector = sector;
        }
    }
}
