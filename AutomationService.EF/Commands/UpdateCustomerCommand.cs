using AutomationService.Domain.Commands;
using AutomationService.Domain.Models;
using AutomationService.EF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Commands
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public UpdateCustomerCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Update(Customer customer)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                CustomerDTO customerDTO = new CustomerDTO()
                {
                    CompanyName = customer.CompanyName,

                };

                context.Customers.Update(customerDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
