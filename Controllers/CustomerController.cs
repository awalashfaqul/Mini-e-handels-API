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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerController(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        // Endpoint to create a new customer profile
        [HttpPost]
        public ActionResult<Customer> CreateCustomer([FromBody] Customer customer)
        {
            var existingCustomer = _customerRepository.GetByEmail(customer.customersEmail);
            if (existingCustomer != null)
            {
                return Conflict("A customer with this email already exists.");
            }

            var createdCustomer = _customerRepository.Create(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.customersId }, createdCustomer);
        }

        // Endpoint to get customer details by ID
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // Endpoint to get all customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            return Ok(customers);
        }

        // Endpoint to update customer profile
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            var existingCustomer = _customerRepository.GetById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            updatedCustomer.customersId = id; // Ensure the ID remains unchanged
            _customerRepository.Update(updatedCustomer);
            return Ok(new { message = "Customer updated successfully" });
        }

        // Endpoint to delete a customer profile
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var existingCustomer = _customerRepository.GetById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerRepository.Delete(id);
            return Ok(new { message = "Customer deleted successfully" });
        }

        // Endpoint to get a customer's order history
        [HttpGet("{id}/orders")]
        public ActionResult<IEnumerable<ShoppingOrder>> GetCustomerOrders(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null) return NotFound();

            var orders = _orderRepository.GetByCustomerId(id);
            return Ok(orders);
        }
    }
}