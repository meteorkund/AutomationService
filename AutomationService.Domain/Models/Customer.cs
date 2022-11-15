using AutomationService.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Models
{
    public class Customer :BaseEntity
    {
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public  ICollection<Breakdown> Breakdowns { get; set; }
        public ICollection<Employee> Employees { get; set; }


    }
}
