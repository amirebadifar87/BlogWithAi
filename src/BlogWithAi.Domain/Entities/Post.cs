namespace BlogWithAi.Domain.Entities;

public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public string? FeaturedImage { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int ViewCount { get; set; }
    
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
