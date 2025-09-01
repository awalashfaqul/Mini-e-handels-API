using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_e_handels_API.Data.Repositories.IRepositories;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
    }
}