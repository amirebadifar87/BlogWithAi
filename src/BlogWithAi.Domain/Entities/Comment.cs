namespace BlogWithAi.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string? AuthorEmail { get; set; }
    public bool IsApproved { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    
    public int? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
    public ICollection<Comment> Replies { get; set; } = new List<Comment>();
}
