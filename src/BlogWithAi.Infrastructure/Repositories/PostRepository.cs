using BlogWithAi.Domain.Entities;
using BlogWithAi.Domain.Interfaces;
using BlogWithAi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogWithAi.Infrastructure.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(BlogDbContext context) : base(context)
    {
    }

    public override async Task<Post?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetPublishedPostsAsync()
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .Where(p => p.IsPublished)
            .OrderByDescending(p => p.PublishedAt)
            .ToListAsync();
    }

    public async Task<Post?> GetBySlugAsync(string slug)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.Slug == slug);
    }

    public async Task<IEnumerable<Post>> GetByCategoryAsync(int categoryId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .Where(p => p.CategoryId == categoryId && p.IsPublished)
            .OrderByDescending(p => p.PublishedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetByTagAsync(int tagId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .Where(p => p.Tags.Any(t => t.Id == tagId) && p.IsPublished)
            .OrderByDescending(p => p.PublishedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetByAuthorAsync(int authorId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .Where(p => p.AuthorId == authorId && p.IsPublished)
            .OrderByDescending(p => p.PublishedAt)
            .ToListAsync();
    }
}
