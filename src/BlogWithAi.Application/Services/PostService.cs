using BlogWithAi.Application.DTOs;
using BlogWithAi.Application.Interfaces;
using BlogWithAi.Domain.Entities;
using BlogWithAi.Domain.Interfaces;

namespace BlogWithAi.Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly ICategoryRepository _categoryRepository;

    public PostService(IPostRepository postRepository, ICategoryRepository categoryRepository)
    {
        _postRepository = postRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
    {
        var posts = await _postRepository.GetAllAsync();
        return posts.Select(MapToDto);
    }

    public async Task<IEnumerable<PostDto>> GetPublishedPostsAsync()
    {
        var posts = await _postRepository.GetPublishedPostsAsync();
        return posts.Select(MapToDto);
    }

    public async Task<PostDto?> GetPostByIdAsync(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        return post != null ? MapToDto(post) : null;
    }

    public async Task<PostDto?> GetPostBySlugAsync(string slug)
    {
        var post = await _postRepository.GetBySlugAsync(slug);
        return post != null ? MapToDto(post) : null;
    }

    public async Task<IEnumerable<PostDto>> GetPostsByCategoryAsync(int categoryId)
    {
        var posts = await _postRepository.GetByCategoryAsync(categoryId);
        return posts.Select(MapToDto);
    }

    public async Task<IEnumerable<PostDto>> GetPostsByTagAsync(int tagId)
    {
        var posts = await _postRepository.GetByTagAsync(tagId);
        return posts.Select(MapToDto);
    }

    public async Task<IEnumerable<PostDto>> GetPostsByAuthorAsync(int authorId)
    {
        var posts = await _postRepository.GetByAuthorAsync(authorId);
        return posts.Select(MapToDto);
    }

    public async Task<PostDto> CreatePostAsync(CreatePostDto createPostDto)
    {
        var post = new Post
        {
            Title = createPostDto.Title,
            Slug = GenerateSlug(createPostDto.Title),
            Content = createPostDto.Content,
            Excerpt = createPostDto.Excerpt,
            FeaturedImage = createPostDto.FeaturedImage,
            IsPublished = createPostDto.IsPublished,
            PublishedAt = createPostDto.IsPublished ? DateTime.UtcNow : null,
            CategoryId = createPostDto.CategoryId,
            AuthorId = createPostDto.AuthorId,
            CreatedAt = DateTime.UtcNow,
            ViewCount = 0
        };

        var createdPost = await _postRepository.AddAsync(post);
        return MapToDto(createdPost);
    }

    public async Task UpdatePostAsync(int id, CreatePostDto updatePostDto)
    {
        var post = await _postRepository.GetByIdAsync(id);
        if (post == null)
            throw new KeyNotFoundException($"Post with id {id} not found");

        post.Title = updatePostDto.Title;
        post.Slug = GenerateSlug(updatePostDto.Title);
        post.Content = updatePostDto.Content;
        post.Excerpt = updatePostDto.Excerpt;
        post.FeaturedImage = updatePostDto.FeaturedImage;
        post.IsPublished = updatePostDto.IsPublished;
        post.PublishedAt = updatePostDto.IsPublished && post.PublishedAt == null ? DateTime.UtcNow : post.PublishedAt;
        post.CategoryId = updatePostDto.CategoryId;
        post.UpdatedAt = DateTime.UtcNow;

        await _postRepository.UpdateAsync(post);
    }

    public async Task DeletePostAsync(int id)
    {
        await _postRepository.DeleteAsync(id);
    }

    public async Task IncrementViewCountAsync(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        if (post != null)
        {
            post.ViewCount++;
            await _postRepository.UpdateAsync(post);
        }
    }

    private static PostDto MapToDto(Post post)
    {
        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Slug = post.Slug,
            Content = post.Content,
            Excerpt = post.Excerpt,
            FeaturedImage = post.FeaturedImage,
            IsPublished = post.IsPublished,
            PublishedAt = post.PublishedAt,
            ViewCount = post.ViewCount,
            CreatedAt = post.CreatedAt,
            UpdatedAt = post.UpdatedAt,
            Category = post.Category != null ? new CategoryDto
            {
                Id = post.Category.Id,
                Name = post.Category.Name,
                Slug = post.Category.Slug,
                Description = post.Category.Description
            } : null,
            Author = new AuthorDto
            {
                Id = post.Author.Id,
                Name = post.Author.Name,
                Email = post.Author.Email,
                Bio = post.Author.Bio,
                Avatar = post.Author.Avatar
            },
            Tags = post.Tags.Select(t => new TagDto
            {
                Id = t.Id,
                Name = t.Name,
                Slug = t.Slug
            }).ToList(),
            CommentCount = post.Comments.Count(c => c.IsApproved)
        };
    }

    private static string GenerateSlug(string title)
    {
        return title.ToLowerInvariant()
            .Replace(" ", "-")
            .Replace("--", "-")
            .Trim('-');
    }
}
