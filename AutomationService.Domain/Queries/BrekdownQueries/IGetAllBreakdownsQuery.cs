using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Queries.BrekdownQueries
{
    public interface IGetAllBreakdownsQuery
    {
        Task<IEnumerable<Breakdown>> GetAllBreakdowns();
    }
}
