using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Data.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        Customer GetById(int id);
        Customer GetByEmail(string email);
        IEnumerable<Customer> GetAll();
        void Update(Customer customer);
        void Delete(int id);
    }
}