using AutomationService.Domain.Models;
using AutomationService.Domain.Queries;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Queries
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

                return customerDTOs.Select(c => new Customer(
                    c.CompanyName,
                    c.Country,
                    new Domain.Models.Common.Breakdown {
                        IsElectrical = c.Breakdowns.FirstOrDefault(b=> b.Id == c.Id).IsElectrical,
                        IsMechanical = c.Breakdowns.FirstOrDefault(b=> b.Id == c.Id).IsMechanical,
                    },
                    new Employee { NameSurname = c.Employees.FirstOrDefault(b=> b.Id == c.Id).NameSurname }
                    ));
            }
        }
    }
}
