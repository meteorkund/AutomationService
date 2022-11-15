using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationService.Domain.Models.Common;

namespace AutomationService.Domain.Models
{
    public class Breakdown : BaseEntity
    {
        public bool Status { get; set; }
        public bool IsElectrical { get; set; }
        public bool IsMechanical { get; set; }
        public string Department { get; set; }
        public string Sector { get; set; }
        public string Service { get; set; }
        public string Cause { get; set; }

        public Customer Customer { get; set; }
        public ICollection<BreakdownFile> BreakdownFiles { get; set; }
    }
}
