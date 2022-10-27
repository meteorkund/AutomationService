using AutomationService.Domain.Commands;
using AutomationService.Domain.Models;
using AutomationService.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class CustomerStore
    {
        readonly IGetAllCustomersQuery _getAllCustomersQuery;
        readonly ICreateCustomerCommand _createCustomerCommand;
        readonly IUpdateCustomerCommand _updateCustomerCommand;
        readonly IDeleteCustomerCommand _deleteCustomerCommand;

        readonly List<Customer> _customers;
        public IEnumerable<Customer> Customers => _customers;



        public event Action CustomersLoaded;
        public event Action<Customer> CustomerAdded;
        public event Action<Customer> CustomerUpdated;
        public event Action<int> CustomerDeleted;


        public CustomerStore(IGetAllCustomersQuery getAllCustomersQuery, ICreateCustomerCommand createCustomerCommand, IUpdateCustomerCommand updateCustomerCommand, IDeleteCustomerCommand deleteCustomerCommand)
        {
            _getAllCustomersQuery = getAllCustomersQuery;
            _createCustomerCommand = createCustomerCommand;
            _updateCustomerCommand = updateCustomerCommand;
            _deleteCustomerCommand = deleteCustomerCommand;

            _customers = new List<Customer>();
        }

        public async Task Add(Customer customer)
        {
            await _createCustomerCommand.Create(customer);

            _customers.Add(customer);

            CustomerAdded?.Invoke(customer);
        }

        public async Task Update(Customer customer)
        {
            await _updateCustomerCommand.Update(customer);

            int currentIndex = _customers.FindIndex(e => e.Id == customer.Id);

            if (currentIndex != -1)
                _customers[currentIndex] = customer;
            else
                _customers.Add(customer);

            CustomerUpdated?.Invoke(customer);
        }

        public async Task Load()
        {
            IEnumerable<Customer> employees = await _getAllCustomersQuery.GetAllCustomers();

            _customers.Clear();
            _customers.AddRange(employees);

            CustomersLoaded?.Invoke();
        }

        public async Task Delete(int id)
        {
            await _deleteCustomerCommand.DeleteCustomer(id);

            _customers.RemoveAll(e => e.Id == id);

            CustomerDeleted?.Invoke(id);
        }

    }
}
