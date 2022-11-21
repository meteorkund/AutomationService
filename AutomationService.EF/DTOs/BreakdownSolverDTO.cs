using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.DTOs
{
    public class BreakdownSolverDTO
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        
        public ICollection<BreakdownDTO> Breakdowns { get; set; }
    }
}
