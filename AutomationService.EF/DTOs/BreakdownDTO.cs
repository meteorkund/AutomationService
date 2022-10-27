using AutomationService.EF.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.DTOs
{
    public class BreakdownDTO : BaseDTO
    {
        public bool Status { get; set; }
        public bool IsElectrical { get; set; }
        public bool IsMechanical { get; set; }
        public string Department { get; set; }
        public string Sector { get; set; }
        public string Service { get; set; }

        public CustomerDTO Customer { get; set; }
        public ICollection<BreadownFile> BreadownFiles { get; set; }
    }
}
