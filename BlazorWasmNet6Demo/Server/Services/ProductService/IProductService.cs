namespace BlazorWasmNet6Demo.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>>GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductsByIdAsync(int id);

        Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string catagoryUrl);
    }
}
