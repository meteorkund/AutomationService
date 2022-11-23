using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationService.Domain.Models.Common;

namespace AutomationService.Domain.Models
{
    public class Breakdown
    {
        public Guid Id { get; set; }

        public int CustomerId { get; set; }
        public int DepartmentId { get; set; }
        public int SectorId { get; set; }
        public int? BreakdownSolverId { get; set; }
        public int EmployeeId { get; set; }

        public bool Status { get; set; }
        public bool IsElectrical { get; set; }
        public bool IsMechanical { get; set; }

        public string Service { get; set; }
        public string Cause { get; set; }

        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public Department Department { get; set; }
        public Sector Sector { get; set; }
        public BreakdownSolver BreakdownSolver { get; set; }
        public ICollection<BreakdownFile> BreakdownFiles { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
        public DateTime SolvedDate { get; set; }
    }
}
