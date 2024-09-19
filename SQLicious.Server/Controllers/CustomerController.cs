using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLicious.Server.Model.DTOs.Customer;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            return Ok(customer);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateCustomer(CustomerCreationDTO customer)
        {
            var newCustomer = await _customerService.CreateCustomerAsync(customer);

            // Log to ensure CustomerId is populated
            Console.WriteLine($"Created Customer ID: {newCustomer.CustomerId}");

            if (newCustomer.CustomerId > 0)
            {
                return Ok(newCustomer.CustomerId);
            }

            return BadRequest("Customer creation failed.");
        }


        [HttpPut("update")]
        public async Task<ActionResult> UpdateCustomer(CustomerDTO customer)
        {
            await _customerService.UpdateCustomerAsync(customer);
            return Ok("Customer updated successfully.");
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteCustomer(int customerId)
        {
            await _customerService.DeleteCustomerAsync(customerId);
            return Ok("Customer deleted successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customersList = await _customerService.GetAllCustomersAsync();
            return Ok(customersList);
        }
    }
}
