using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Models.Common
{
    public class BreakdownSolver
    {
        public BreakdownSolver(int id, string nameSurname)
        {
            Id = id;
            NameSurname = nameSurname;
        }

        public int Id { get; set; }
        public string NameSurname { get; set; }
    }
}
