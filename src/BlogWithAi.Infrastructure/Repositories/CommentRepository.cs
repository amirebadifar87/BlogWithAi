using BlogWithAi.Domain.Entities;
using BlogWithAi.Domain.Interfaces;
using BlogWithAi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogWithAi.Infrastructure.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(BlogDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> GetByPostIdAsync(int postId)
    {
        return await _dbSet
            .Include(c => c.Replies)
            .Where(c => c.PostId == postId && c.ParentCommentId == null)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Comment>> GetApprovedByPostIdAsync(int postId)
    {
        return await _dbSet
            .Include(c => c.Replies)
            .Where(c => c.PostId == postId && c.ParentCommentId == null && c.IsApproved)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }
}
