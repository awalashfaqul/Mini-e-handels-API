using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_e_handels_API.Models
{
    public class Customer
    {
        public int customersId { get; set; }                    // Unique identifier
        public string customersName { get; set; }               // Customer full name
        public string customersEmail { get; set; }              // Email (used for notifications)
        public string customersShippingAddress { get; set; }    // Default shipping address
        public string customersMembershipLevel { get; set; } = "Standard"; // e.g., Standard, Silver, Gold
        public int customersTotalOrders { get; set; } = 0;     // Track total orders for loyalty/membership
        public List<int> customersOrderIds { get; set; } = new(); // List of orders placed
    }
}