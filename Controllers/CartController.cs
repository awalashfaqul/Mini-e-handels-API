using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_e_handels_API.Data.Repositories.IRepositories;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Data.Repositories;

namespace Mini_e_handels_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        // Controller for managing shopping carts
        // This controller provides endpoints to create, retrieve, update, and clear shopping carts
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CartController(ICartRepository cartRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        [HttpPost]
        public ActionResult CreateCart()
        {
            var cart = _cartRepository.CreateCart();
            return Ok(cart);
        }

        [HttpGet("{id}")]
        public ActionResult GetCartById(int id)
        {
            var cart = _cartRepository.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost("{cartId}/add/{productId}")]
        public ActionResult AddItem(int cartId, int productId, [FromQuery] int qty = 1)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null) return NotFound("Product not found");

            var item = new ShoppingCartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = qty
            };

            _cartRepository.AddItem(cartId, item);
            return Ok(new { Message = "Item added to cart" });
        }

        [HttpPost("{cartId}/clear")]
        public ActionResult ClearCart(int cartId)
        {
            _cartRepository.ClearCart(cartId);
            return Ok(new { Message = "Cart cleared" });
        }
        [HttpPost("{cartId}/checkout")]
        public ActionResult<ShoppingOrder> Checkout(int cartId)
        {
            var cart = _cartRepository.GetCartById(cartId);
            if (cart == null || !cart.CartItems.Any())
            {
                return BadRequest("Cart is empty");
            }

            var order = _orderRepository.CreateOrder(cart);
            _cartRepository.ClearCart(cartId);
            return Ok(order);
        }
    }
}