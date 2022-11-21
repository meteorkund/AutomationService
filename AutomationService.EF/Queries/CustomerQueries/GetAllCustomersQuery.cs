using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.Domain.Queries.CustomerQueries;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Queries.CustomerQueries
{
    public class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public GetAllCustomersQuery(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                IEnumerable<CustomerDTO> customerDTOs = await context.Customers.ToListAsync();
                return customerDTOs.Select(d => new Customer(
                    d.Id,
                    d.CompanyName,
                    d.Country
                    ));
            }
        }
    }
}
