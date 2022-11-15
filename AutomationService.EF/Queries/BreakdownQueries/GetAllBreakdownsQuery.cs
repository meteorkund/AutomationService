using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.BrekdownQueries;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Queries.BreakdownQueries
{
    public class GetAllBreakdownsQuery : IGetAllBreakdownsQuery
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public GetAllBreakdownsQuery(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Breakdown>> GetAllBreakdowns()
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                IEnumerable<BreakdownDTO> breakdownDTOs = await context.Breakdowns
                    .Include(c => c.Customer)
                    .Include(f => f.BreadownFiles)
                    .ToListAsync();

                return breakdownDTOs.Select(e => new Breakdown
                {
                    Id = e.Id,

                    Department = e.Department,
                    Sector = e.Sector,
                    IsElectrical = e.IsElectrical,
                    IsMechanical = e.IsMechanical,
                    Cause = e.Cause,
                    Service = e.Service,

                    Customer = new Customer { CompanyName = e.Customer.CompanyName, Country = e.Customer.Country }

                });



            }
        }
    }
}
