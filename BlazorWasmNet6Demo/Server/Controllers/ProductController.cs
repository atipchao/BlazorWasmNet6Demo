using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmNet6Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
        {
            //Ideally Controller should call "Services" to do the work on getting data or whatever.
            //There shouldn't be Dbcontext in controller code - it should be in Service.
            var products = await _context.Products.ToListAsync();

            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };
              return Ok(response); 
        }
    }
}
