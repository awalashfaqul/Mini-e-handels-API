using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Data.Repositories.IRepositories
{
    public interface IOrderRepository
    {
        ShoppingOrder CreateOrder(ShoppingCart cart, Customer? customer = null); // Modified to accept an optional Customer parameter
        IEnumerable<ShoppingOrder> GetAll();
        ShoppingOrder GetById(int id);
        void Create(ShoppingOrder order);
        void Update(ShoppingOrder order);
        void Delete(int id);
        IEnumerable<ShoppingOrder> GetByCustomerId(int customerId); // New method to get orders by customer ID. This will make tracking customer order history easier.

    }
}