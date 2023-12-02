namespace BlazorWasmNet6Demo.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>>GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductsByIdAsync(int id);
        Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string catagoryUrl);
        Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
        Task<ServiceResponse<List<String>>> GetProductSearchSuggestions(string SearchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
    }
}
