using AutomationService.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Models
{
    public class Employee : BaseEntity
    {

        public string NameSurname { get; set; }
        public ICollection<Customer> Customer { get; set; } 
    }
}
