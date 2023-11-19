using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmNet6Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //NOTE DbContext should NOT be used in Controller - put it in Service class instead
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            //Ideally Controller should call "Services" to do the work on getting data or whatever.
            //There shouldn't be Dbcontext in controller code - it should be in Service.
            //Instead, we use serveice here to fetch Products data
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductsByIdAsync(int id)
        {
            var result = await _productService.GetProductsByIdAsync(id);
            return Ok(result);
        }
    }
}
