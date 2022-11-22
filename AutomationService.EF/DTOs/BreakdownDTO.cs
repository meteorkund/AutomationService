using AutomationService.EF.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.DTOs
{
    public class BreakdownDTO : BaseDTO
    {

        public Guid Id { get; set; }

        public int CustomerId { get; set; }
        public int DepartmentId { get; set; }
        public int SectorId { get; set; }
        public int BreakdownSolverId { get; set; }
        public int EmployeeId { get; set; }

        public bool Status { get; set; }
        public bool IsElectrical { get; set; }
        public bool IsMechanical { get; set; }

        public string? Service { get; set; }
        public string? Cause { get; set; }

        public EmployeeDTO Employee { get; set; }
        public CustomerDTO Customer { get; set; }
        public DepartmentDTO Department { get; set; }
        public SectorDTO Sector { get; set; }
        public BreakdownSolverDTO? BreakdownSolver { get; set; }


        public ICollection<BreakdownFileDTO>? BreadownFiles { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
