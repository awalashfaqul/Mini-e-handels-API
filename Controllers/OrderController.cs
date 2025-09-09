using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_e_handels_API.Data.Repositories.IRepositories;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Services.IServices;

namespace Mini_e_handels_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationService _notificationService;

        public OrderController(
            IOrderRepository orderRepository,
            ICartRepository cartRepository,
            ICustomerRepository customerRepository,
            INotificationService notificationService)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingOrder> GetById(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShoppingOrder>> GetAll()
        {
            var orders = _orderRepository.GetAll();
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult Create(ShoppingOrder order)
        {
            _orderRepository.Create(order);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ShoppingOrder order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var existingOrder = _orderRepository.GetById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _orderRepository.Update(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingOrder = _orderRepository.GetById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _orderRepository.Delete(id);
            return NoContent();
        }

        [HttpPost("checkout")]
        public ActionResult<ShoppingOrder> Checkout(int cartId, [FromQuery] int? customerId = null)
        {
            var cart = _cartRepository.GetCartById(cartId);
            if (cart == null || !cart.CartItems.Any())
                return BadRequest("Cart is empty");

            Customer customer = null;
            if (customerId.HasValue)
                customer = _customerRepository.GetById(customerId.Value);

            var order = _orderRepository.CreateOrder(cart, customer);

            _cartRepository.ClearCart(cartId);

            // Send email notification
            _notificationService.SendOrderConfirmation(order);

            return Ok(order);
        }

        [HttpPut("{id}/place")]
        public IActionResult PlaceOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) return NotFound();

            order.Status = "Placed";
            _orderRepository.Update(order);

            _notificationService.SendOrderConfirmation(order);

            return Ok(order);
        }


        [HttpPut("{id}/cancel")]
        public IActionResult CancelOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) return NotFound();

            order.Status = "Cancelled";
            _orderRepository.Update(order);

            _notificationService.SendOrderCancellation(order);

            return Ok(order);
        }



    }
}