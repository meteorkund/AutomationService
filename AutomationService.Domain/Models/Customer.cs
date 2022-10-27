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
        public Customer(string companyName, string country, Breakdown breakdown, Employee employee)
        {
            CompanyName = companyName;
            Country = country;
            Breakdown = breakdown;
            Employee = employee;
        }

        public string CompanyName { get;  }
        public string Country { get;  }
        public Breakdown Breakdown { get; }
        public Employee Employee { get; }


    }
}
