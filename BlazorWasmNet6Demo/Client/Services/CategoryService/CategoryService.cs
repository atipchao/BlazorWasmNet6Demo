
using BlazorWasmNet6Demo.Shared;

namespace BlazorWasmNet6Demo.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public Category Category { get; set; } = new Category(); 
        

        public async Task GetCategories()
        {
            var result =
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            if (result != null && result.Data != null)
            {
                Categories = result.Data;
            }
        }

        public async Task<ServiceResponse<Category>> GetCategoryById(int id)
        {
            var result =
                await _httpClient.GetFromJsonAsync<ServiceResponse<Category>>($"api/category/{id}");
            return result;
        }
    }
}
