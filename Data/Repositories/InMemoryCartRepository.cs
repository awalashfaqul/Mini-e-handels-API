using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Data.Repositories.IRepositories;

namespace Mini_e_handels_API.Data.Repositories
{
    public class InMemoryCartRepository : ICartRepository
    {
        private readonly List<ShoppingCart> _carts = new();

        public ShoppingCart GetAllCarts()
        {
            return _carts.FirstOrDefault();
        }

        public ShoppingCart GetCartById(int id)
        {
            return _carts.FirstOrDefault(c => c.Id == id);
        }

        public void AddItem(int cartId, ShoppingCartItem item)
        {
            var cart = GetCartById(cartId);
            if (cart != null)
            {
                cart.CartItems.Add(item);
            }
        }
/*
        public void UpdateCart(ShoppingCart cart)
        {
            var existingCart = GetCartById(cart.Id);
            if (existingCart != null)
            {
                _carts.Remove(existingCart);
                _carts.Add(cart);
            }
        }
*/
        public void RemoveItem(int cartId, int productId)
        {
            var cart = GetCartById(cartId);
            if (cart != null)
            {
                var item = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);
                if (item != null)
                {
                    cart.CartItems.Remove(item);
                }
            }
        }

        public void ClearCart(int id)
        {
            var cart = GetCartById(id);
            if (cart != null)
            {
                cart.CartItems.Clear();
            }
        }

        public ShoppingCart CreateCart()
        {
            var newCart = new ShoppingCart
            {
                Id = _carts.Count + 1
            };
            _carts.Add(newCart);
            return newCart;
        }
    }
}