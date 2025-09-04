using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_e_handels_API.Models
{
    public class ShoppingOrder
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }             // Link to Customer profile
        public List<ShoppingCartItem> OrderItems { get; set; } = new();
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        

        // New fields for Optimizely-like features
        public string Status { get; set; } = "Reserved"; // Reserved / Placed / Cancelled
        public decimal DiscountApplied { get; set; } = 0; // Membership discount amount
    }
}