
using BlazorWasmNet6Demo.Shared.DTO;
using System.Dynamic;

namespace BlazorWasmNet6Demo.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Product> Products { get; set; } = new List<Product>();

        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public Product Product { get; set; } = new Product();


        public event Action ProductChanged;

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var result =
                await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            CurrentPage = 1;
            PageCount = 0;
            if(Products.Count == 0)
            {
                Message = "No Products found...";
            }
            //Here's we invoke ProductChanged Event - meaning telling everything that connected to this event to have to do some things. 
            ProductChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggesstion(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            LastSearchText = searchText;
            var result = await _httpClient
                .GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/search/{searchText}/{page}"); 
            if(result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;                
            }
            if(Products.Count == 0)
            {
                Message = "No products found.";
            }
            ProductChanged?.Invoke();
        }
    }
}
