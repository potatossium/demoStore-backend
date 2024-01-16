using DemoStoreWeek7.Services;
using DemoStoreWeek7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DemoStoreWeek7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> Get()
        {
            var stores = await _storeService.GetStores();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Store))]
        public async Task<IActionResult> GetSingle(int? id)
        {
            var store = await _storeService.GetStore(id);

            if (store == null)
            {
                return NotFound("Could not find the store with this id");
            }

            return Ok(store);
        }

        [HttpPost]
        // [Route("Create")]
        public async Task<IActionResult> CreateStore([FromBody] CreateStore model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _storeService.CreateStore(model);
            return Ok(id);
        }

        [HttpPut]
        // [Route("Update")]
        public async Task<IActionResult> UpdateStore([FromBody] UpdateStore model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _storeService.UpdateStore(model);
            return Ok(store);
        }

        [HttpDelete]
        //[Route("Delete")]
        public async Task DeleteStore(int id)
        {
            await _storeService.DeleteStore(id);
        }
    }
}
