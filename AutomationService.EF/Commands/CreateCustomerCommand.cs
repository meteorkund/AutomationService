using AutomationService.Domain.Commands;
using AutomationService.Domain.Models;
using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Commands
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public CreateCustomerCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Create(Customer customer)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {
                CustomerDTO customerDTO = new CustomerDTO()
                {
                    CompanyName = customer.CompanyName,
                    
                };

                context.Customers.Add(customerDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
