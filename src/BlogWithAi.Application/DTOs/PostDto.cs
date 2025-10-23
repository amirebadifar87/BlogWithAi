namespace BlogWithAi.Application.DTOs;

public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public string? FeaturedImage { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public CategoryDto? Category { get; set; }
    public AuthorDto Author { get; set; } = null!;
    public List<TagDto> Tags { get; set; } = new();
    public int CommentCount { get; set; }
}
