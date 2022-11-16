using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Queries.BreakdownFileQueries
{
    public interface IGetAllBreakdownFilesQuery
    {
        Task<IEnumerable<BreakdownFile>> GetAllBreakdownFiles();

    }
}
