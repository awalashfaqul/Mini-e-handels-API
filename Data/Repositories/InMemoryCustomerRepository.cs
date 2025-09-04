using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Data.Repositories.IRepositories;

namespace Mini_e_handels_API.Data.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        // Implementation of the ICustomerRepository interface using in-memory storage
        private readonly List<Customer> _customers = new();

        public Customer Create(Customer customer)
        {
            customer.customersId = _customers.Count + 1;
            _customers.Add(customer);
            return customer;
        }

        public Customer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.customersId == id);
        }

        public Customer GetByEmail(string email)
        {
            return _customers.FirstOrDefault(c => c.customersEmail == email);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public void Update(Customer customer)
        {
            var existing = GetById(customer.customersId);
            if (existing != null)
            {
                existing.customersName = customer.customersName;
                existing.customersEmail = customer.customersEmail;
                existing.customersShippingAddress = customer.customersShippingAddress;
                existing.customersMembershipLevel = customer.customersMembershipLevel;
                existing.customersTotalOrders = customer.customersTotalOrders;
                existing.customersOrderIds = customer.customersOrderIds;
            }
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }
}