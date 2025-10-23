using BlogWithAi.Domain.Entities;
using BlogWithAi.Domain.Interfaces;
using BlogWithAi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogWithAi.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(BlogDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetBySlugAsync(string slug)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.Slug == slug);
    }
}
