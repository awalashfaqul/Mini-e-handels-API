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

        public ShoppingOrder CreateOrder(ShoppingCart cart, Customer customer = null)
        {
            decimal discount = 0;
            string status = "Placed";

            if (customer != null)
            {
                // Apply membership discount
                switch (customer.customersMembershipLevel)
                {
                    case "Silver": discount = 0.05m; break; // 5%
                    case "Gold": discount = 0.1m; break;    // 10%
                }

                customer.customersTotalOrders += 1; // Increment total orders
            }

            int totalPrice = cart.TotalPrice;
            int discountedPrice = (int)(totalPrice * (1 - discount));

            var order = new ShoppingOrder
            {
                Id = _orders.Count + 1,
                CustomerId = customer?.customersId,
                OrderItems = cart.CartItems,
                TotalAmount = discountedPrice,
                Status = status,
                DiscountApplied = (decimal)discount * totalPrice,
                OrderDate = DateTime.Now};

            _orders.Add(order);

            // Link order to customer profile
            if (customer != null)
                customer.customersOrderIds.Add(order.Id);

            return order;
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

        public IEnumerable<ShoppingOrder> GetByCustomerId(int customerId)
        {
            return _orders.Where(o => o.CustomerId == customerId);
        }
    }
}