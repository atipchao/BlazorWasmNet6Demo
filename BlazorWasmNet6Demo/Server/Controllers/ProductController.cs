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
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            //Ideally Controller should call Server to do the work on getting data.
            //There shouldn't be _context in controller code.
            var products = await _context.Products.ToListAsync(); 
              return Ok(products); 
        }
    }
}
