

namespace BlazorWasmNet6Demo.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Include(p => p.Variants)
                .ToListAsync()

            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string? categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.Where(s => s.Category.Url.ToLower() == categoryUrl.ToLower())
                    .Include(p => p.Variants)
                    .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductsByIdAsync(int id)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(product == null)
            {
                response.Success = false;
                response.Message = "Product Not found id: " + id.ToString();
            }
            else
            {
                response.Data = product;
            }
            return response;
        }
    }
}
