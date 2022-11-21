using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.CustomerQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class CustomerStore
    {
        readonly IGetAllCustomersQuery _getAllCustomers;
        readonly List<Customer> _customers;
        public IEnumerable<Customer> Customers => _customers;

        public event Action CustomersLoaded;

        public CustomerStore(IGetAllCustomersQuery getAllCustomers)
        {
            _getAllCustomers = getAllCustomers;
            _customers = new List<Customer>();
        }

        public async Task LoadCustomers()
        {
            IEnumerable<Customer> customers = await _getAllCustomers.GetAllCustomers();

            _customers.Clear();

            IEnumerable<Customer> sortedCustomers = customers.OrderBy(c => c.Country).ToArray();

            _customers.AddRange(sortedCustomers);

            CustomersLoaded?.Invoke();
        }
    }
}
