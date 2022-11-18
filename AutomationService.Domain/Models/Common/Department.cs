using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Models.Common
{
    public class Department
    {
        public Department(int id, string departmentName)
        {
            Id = id;
            DepartmentName = departmentName;
        }

        public int Id { get; }
        public string DepartmentName { get; }
    }
}
