

namespace BlazorWasmNet6Demo.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.Where(s => s.Featured)
                .Include(s => s.Variants)
                .ToListAsync()
            };
            return response;
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

            if (product == null)
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

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string SearchText)
        {
            var products = await FindProductBySearchText(SearchText);
            List<String> result = new List<string>();

            foreach (var product in products)
            {
                if(product.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }
                if(product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if(word.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }

                }

            }

            return new ServiceResponse<List<string>>{Data = result};

        }

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await FindProductBySearchText(searchText)
            };
            return response;
        }

        private async Task<List<Product>> FindProductBySearchText(string searchText)
        {
            return await _context.Products
                            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower()))
                            .Include(p => p.Variants)
                            .ToListAsync();
        }
    }
}

