using BlogWithAi.Domain.Entities;

namespace BlogWithAi.Domain.Interfaces;

public interface IPostRepository : IRepository<Post>
{
    Task<IEnumerable<Post>> GetPublishedPostsAsync();
    Task<Post?> GetBySlugAsync(string slug);
    Task<IEnumerable<Post>> GetByCategoryAsync(int categoryId);
    Task<IEnumerable<Post>> GetByTagAsync(int tagId);
    Task<IEnumerable<Post>> GetByAuthorAsync(int authorId);
}
