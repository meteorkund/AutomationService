using AutomationService.EF.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.DTOs
{
    public class BreadownFile : BaseDTO
    {
        public string FileName { get; set; }
        public string Path { get; set; }

        public BreakdownDTO Breakdown { get; set; }
    }
}
