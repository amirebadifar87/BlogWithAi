using BlogWithAi.Domain.Entities;

namespace BlogWithAi.Domain.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetBySlugAsync(string slug);
}
