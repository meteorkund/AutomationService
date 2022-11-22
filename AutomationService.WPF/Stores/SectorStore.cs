using AutomationService.Domain.Models.Common;
using AutomationService.Domain.Queries;
using AutomationService.WPF.ViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.SectorViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class SectorStore : ViewModelBase
    {
        readonly IGetAllSectorsQuery _getAllSectors;

        readonly List<Sector> _sectors;
        public IEnumerable<Sector> Sectors => _sectors;

        public ObservableCollection<SectorListingItemViewModel> _sectorListingItemViewModels;

        public event Action SectorsLoaded;

        public SectorStore(IGetAllSectorsQuery getAllSectors)
        {
            _getAllSectors = getAllSectors;
            _sectors = new List<Sector>();

            _sectorListingItemViewModels= new ObservableCollection<SectorListingItemViewModel>();

            SectorsLoaded += SectorStore_SectorsLoaded;
        }


        public async Task LoadSectors()
        {

            IEnumerable<Sector> sectors = await _getAllSectors.GetAllSectors();

            _sectors.Clear();

            IEnumerable<Sector> sortedSectors = sectors.OrderBy(d => d.SectorName).ToList();

            _sectors.AddRange(sortedSectors);

            SectorsLoaded?.Invoke();
        }

        private void SectorStore_SectorsLoaded()
        {
            _sectorListingItemViewModels.Clear();
            foreach (Sector sector in Sectors)
            {
                AddBreakdownSolver(sector);
            }
        }
        private void AddBreakdownSolver(Sector sector)
        {
            SectorListingItemViewModel itemViewModel = new SectorListingItemViewModel(sector);

            _sectorListingItemViewModels.Add(itemViewModel);
        }

        protected override void Dispose()
        {
            SectorsLoaded -= SectorStore_SectorsLoaded;

            base.Dispose();
        }
    }
}
