using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Data.Repositories.IRepositories;

namespace Mini_e_handels_API.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<ShoppingOrder> _orders = new();

        public ShoppingOrder CreateOrder(ShoppingCart cart)
        {
            var newOrder = new ShoppingOrder
            {
                Id = _orders.Count + 1,
                OrderItems = cart.CartItems,
                TotalAmount = cart.TotalPrice
            };
            _orders.Add(newOrder);
            return newOrder;
        }

        public IEnumerable<ShoppingOrder> GetAll()
        {
            return _orders;
        }

        public ShoppingOrder GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void Create(ShoppingOrder order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
        }

        public void Update(ShoppingOrder order)
        {
            var existingOrder = GetById(order.Id);
            if (existingOrder != null)
            {
                _orders.Remove(existingOrder);
                _orders.Add(order);
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                _orders.Remove(order);
            }
        }
    }
}