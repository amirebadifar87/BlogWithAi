namespace BlogWithAi.Application.DTOs;

public class CreatePostDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public string? FeaturedImage { get; set; }
    public bool IsPublished { get; set; }
    public int? CategoryId { get; set; }
    public int AuthorId { get; set; }
    public List<int> TagIds { get; set; } = new();
}
