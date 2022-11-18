using AutomationService.EF.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }

        public ICollection<CustomerDTO> CustomersDTO { get; set; }
    }
}


