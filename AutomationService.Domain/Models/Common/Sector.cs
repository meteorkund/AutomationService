using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Models.Common
{
    public class Sector
    {
        public Sector(int id, string sectorName)
        {
            Id = id;
            SectorName = sectorName;
        }

        public int Id { get; }
        public string SectorName { get; }
    }
}
