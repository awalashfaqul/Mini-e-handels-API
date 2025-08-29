using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Data.Repositories.IRepositories
{
    public interface ICartRepository
    {
        // Interface for cart repository
        // This interface defines the methods for managing shopping carts in the e-commerce API
        ShoppingCart GetAllCarts(); // Retrieve all shopping carts
        ShoppingCart GetCartById(int id); // Retrieve a shopping cart by its ID
        void AddItem(int cartId, ShoppingCartItem item); // Add a new item to the cart
        void UpdateCart(ShoppingCart cart); // Update an existing shopping cart
        void RemoveItem(int cartId, int productId); // Remove an item from the cart
        void ClearCart(int id); // Clear all items from a shopping cart by its ID
    }
}