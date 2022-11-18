using AutomationService.Domain.Models.Common;
using AutomationService.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class SectorStore
    {
        readonly IGetAllSectorsQuery _getAllSectors;

        readonly List<Sector> _sectors;
        public IEnumerable<Sector> Sectors => _sectors;

        public event Action SectorsLoaded;

        public SectorStore(IGetAllSectorsQuery getAllSectors)
        {
            _getAllSectors = getAllSectors;
            _sectors = new List<Sector>();
        }

        public async Task LoadSectors()
        {

            IEnumerable<Sector> sectors = await _getAllSectors.GetAllSectors();

            _sectors.Clear();

            IEnumerable<Sector> sortedSectors = sectors.OrderBy(d => d.SectorName).ToList();

            _sectors.AddRange(sortedSectors);

            SectorsLoaded?.Invoke();
        }
    }
}
