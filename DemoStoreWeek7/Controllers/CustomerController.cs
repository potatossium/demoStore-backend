using DemoStoreWeek7.Services;
using DemoStoreWeek7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DemoStoreWeek7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly DemoStoreDBContext _context;
        public CustomerController(ICustomerService customerService, DemoStoreDBContext context)
        {
            _customerService = customerService;
            _context = context;
        }

        // test navigation properties
        [HttpGet("getNavProp")]
        public ActionResult GetNavProp()
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id==2);
            var csales = _context.Entry(customer).Collection(c => c.ProductSold);
            return Ok(csales);
/*            var productSold = _context.Customers.Include(c => c.ProductSold);
            if (productSold == null)
            {
                return BadRequest();
            }
            return Ok(productSold);*/
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Customer))]
        public async Task<IActionResult> GetSingle(int? id)
        {
            var customer = await _customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound("Could not find the customer with this id");
            }

            return Ok(customer);
        }

        [HttpPost]
        // [Route("Create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _customerService.CreateCustomer(model);
            return Ok(id);
        }

        [HttpPut]
        // [Route("Update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _customerService.UpdateCustomer(model);
            return Ok(customer);
        }

        [HttpDelete]
        //[Route("Delete")]
        public async Task DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);
        }
    }
}
