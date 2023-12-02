namespace BlazorWasmNet6Demo.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductChanged;
        List<Product> Products { get; set; }
        string Message { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task <ServiceResponse<Product>> GetProductById(int id);
        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggesstion(string searchText);

    }
}
