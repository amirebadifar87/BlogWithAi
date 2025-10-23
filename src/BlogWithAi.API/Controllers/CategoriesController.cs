using BlogWithAi.Application.DTOs;
using BlogWithAi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithAi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpGet("slug/{slug}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryBySlug(string slug)
    {
        var category = await _categoryService.GetCategoryBySlugAsync(slug);
        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto categoryDto)
    {
        var category = await _categoryService.CreateCategoryAsync(categoryDto);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
    {
        try
        {
            await _categoryService.UpdateCategoryAsync(id, categoryDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}
