using DemoStoreWeek7.Services;
using DemoStoreWeek7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DemoStoreWeek7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Product))]
        public async Task<IActionResult> GetSingle(int? id)
        {
            var product = await _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound("Could not find the product with this id");
            }

            return Ok(product);
        }

        [HttpPost]
        // [Route("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _productService.CreateProduct(model);
            return Ok(id);
        }

        [HttpPut]
        // [Route("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.UpdateProduct(model);
            return Ok(product);
        }

        [HttpDelete]
        //[Route("Delete")]
        public async Task DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
        }
    }
}
