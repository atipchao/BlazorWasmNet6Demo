namespace BlazorWasmNet6Demo.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductChanged;
        List<Product> Products { get; set; }
        string Message { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public string LastSearchText { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task <ServiceResponse<Product>> GetProductById(int id);
        Task SearchProducts(string searchText, int page);
        Task<List<string>> GetProductSearchSuggesstion(string searchText);

    }
}
