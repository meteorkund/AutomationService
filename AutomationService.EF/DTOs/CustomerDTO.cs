using AutomationService.EF.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.DTOs
{
    public class CustomerDTO : BaseDTO
    {
        public string CompanyName { get; set; }
        public string Country { get; set; }

        public ICollection<BreakdownDTO> Breakdowns { get; set; }
        public ICollection<EmployeeDTO> Employees { get; set; }
    }
}
