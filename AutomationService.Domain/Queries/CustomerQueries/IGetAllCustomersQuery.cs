using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Queries.CustomerQueries;

public interface IGetAllCustomersQuery
{
    Task<IEnumerable<Customer>> GetAllCustomers();
}
