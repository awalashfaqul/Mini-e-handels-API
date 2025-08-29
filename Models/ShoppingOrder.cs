using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_e_handels_API.Models
{
    public class ShoppingOrder
    {
        public int Id { get; set; }
        public List<ShoppingCartItem> OrderItems { get; set; } = new();
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
    }
}