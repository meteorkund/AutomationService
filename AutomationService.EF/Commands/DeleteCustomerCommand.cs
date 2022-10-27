using AutomationService.Domain.Commands;
using AutomationService.EF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF.Commands
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        readonly AutomationServiceDBContextFactory _contextFactory;

        public DeleteCustomerCommand(AutomationServiceDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task DeleteCustomer(int id)
        {
            using (AutomationServiceDBContext context = _contextFactory.Create())
            {

                CustomerDTO customerDTO = new CustomerDTO()
                {
                    Id = id,
                };

                context.Customers.Remove(customerDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
