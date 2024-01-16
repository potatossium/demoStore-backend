using DemoStoreWeek7.Services;
using DemoStoreWeek7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DemoStoreWeek7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly DemoStoreDBContext _context;
        public SaleController(ISaleService saleService, DemoStoreDBContext context)
        {
            _saleService = saleService;
            _context = context;
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> Get()
        {
            /*            var sales = await _saleService.GetSales();
                        return Ok(sales);*/
            var sales = await _context.Sales.Include(s => s.Customer).Include(s => s.Product).Include(s => s.Store).ToListAsync();
            // map the sales to salesDto
            var salesDto = sales.Select(s => new SaleDto
            {
                Id = s.Id,
                CustomerId = s.CustomerId,
                ProductId = s.ProductId,
                StoreId = s.StoreId,
                DateSold = s.DateSold,
                CustomerName = s.Customer.Name,
                ProductName = s.Product.Name,
                StoreName = s.Store.Name
            });
            return Ok(salesDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Sale))]
        public async Task<IActionResult> GetSingle(int? id)
        {
            var sale = await _saleService.GetSale(id);

            if (sale == null)
            {
                return NotFound("Could not find the sale with this id");
            }

            return Ok(sale);
        }

        [HttpPost]
        // [Route("Create")]
        public async Task<IActionResult> CreateSale([FromBody] CreateSale model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _saleService.CreateSale(model);
            return Ok(id);
        }

        [HttpPut]
        // [Route("Update")]
        public async Task<IActionResult> UpdateSale([FromBody] UpdateSale model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sale = await _saleService.UpdateSale(model);
            return Ok(sale);
        }

        [HttpDelete]
        //[Route("Delete")]
        public async Task DeleteSale(int id)
        {
            await _saleService.DeleteSale(id);
        }
    }
}
