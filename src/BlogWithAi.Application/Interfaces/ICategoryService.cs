using BlogWithAi.Application.DTOs;

namespace BlogWithAi.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto?> GetCategoryByIdAsync(int id);
    Task<CategoryDto?> GetCategoryBySlugAsync(string slug);
    Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
    Task UpdateCategoryAsync(int id, CategoryDto categoryDto);
    Task DeleteCategoryAsync(int id);
}
