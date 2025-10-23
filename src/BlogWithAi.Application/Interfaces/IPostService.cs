using BlogWithAi.Application.DTOs;

namespace BlogWithAi.Application.Interfaces;

public interface IPostService
{
    Task<IEnumerable<PostDto>> GetAllPostsAsync();
    Task<IEnumerable<PostDto>> GetPublishedPostsAsync();
    Task<PostDto?> GetPostByIdAsync(int id);
    Task<PostDto?> GetPostBySlugAsync(string slug);
    Task<IEnumerable<PostDto>> GetPostsByCategoryAsync(int categoryId);
    Task<IEnumerable<PostDto>> GetPostsByTagAsync(int tagId);
    Task<IEnumerable<PostDto>> GetPostsByAuthorAsync(int authorId);
    Task<PostDto> CreatePostAsync(CreatePostDto createPostDto);
    Task UpdatePostAsync(int id, CreatePostDto updatePostDto);
    Task DeletePostAsync(int id);
    Task IncrementViewCountAsync(int id);
}
