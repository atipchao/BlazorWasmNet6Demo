﻿namespace BlazorWasmNet6Demo.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
        Task<ServiceResponse<Category>> GetCategoryByIdAsync(int id);
    }
}
