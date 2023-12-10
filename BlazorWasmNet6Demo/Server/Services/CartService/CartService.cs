
//using BlazorWasmNet6Demo.Shared;

namespace BlazorWasmNet6Demo.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;

        public CartService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponse>>
            {
                Data = new List<CartProductResponse>()
            };
            foreach (var item in cartItems)
            {

                var product = await _context.Products
                    .Where(s => s.Id == item.ProductId)
                    .FirstOrDefaultAsync();

                if(product == null)
                {
                    continue;
                }
                
                var productVariant = await _context.ProductVariants
                    .Where(s => s.ProductId == item.ProductId
                    && s.ProductTypeId == item.ProductTypeId)
                    .Include(s => s.ProductType)
                    .FirstOrDefaultAsync();
                if(productVariant == null)
                {
                    continue;
                }

                var cartProduct = new CartProductResponse
                {
                    ProductId = item.ProductId,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    ProductTpye = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }
            return result;
        }
    }
}
