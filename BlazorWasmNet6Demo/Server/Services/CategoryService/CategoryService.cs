
namespace BlazorWasmNet6Demo.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var response = new ServiceResponse<List<Category>>
            {
                Data = await _context.Categories.ToListAsync()

            };
            return response;
        }

        public async Task<ServiceResponse<Category>> GetCategoryByIdAsync(int id)
        {
            var response = new ServiceResponse<Category>();
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                response.Success = false;
                response.Message = "Category Not found id: " + id.ToString();
            }
            else
            {
                response.Data = category;
            }
            return response;
        }
    }
}
