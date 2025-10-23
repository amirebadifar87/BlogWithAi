using BlogWithAi.Domain.Entities;

namespace BlogWithAi.Domain.Interfaces;

public interface ICommentRepository : IRepository<Comment>
{
    Task<IEnumerable<Comment>> GetByPostIdAsync(int postId);
    Task<IEnumerable<Comment>> GetApprovedByPostIdAsync(int postId);
}
