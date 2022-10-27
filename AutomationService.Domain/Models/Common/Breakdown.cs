using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Models.Common
{
    public class Breakdown :BaseEntity
    {
        public bool Status { get; set; }
        public bool IsElectrical { get; set; }
        public bool IsMechanical { get; set; }
    }
}
