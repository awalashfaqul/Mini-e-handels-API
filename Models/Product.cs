using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_e_handels_API.Models
{
    public class Product
    {
        public int Id { get; set; }            // Unique identifier for the product
        public string Name { get; set; }        // Name of the product
        public string Description { get; set; } // Description of the product
        
        public string Category { get; set; }   // Category of the product
        public int Price { get; set; }          // Price of the product
        
    }
}