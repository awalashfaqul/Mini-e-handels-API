using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_e_handels_API.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        //public List<Product> Products { get; set; } = new List<Product>();
        public List<ShoppingCartItem> CartItems { get; set; } = new();
        public int TotalPrice => CartItems.Sum(item => item.Price * item.Quantity);
    }

    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}