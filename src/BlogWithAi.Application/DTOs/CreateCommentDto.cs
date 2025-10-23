namespace BlogWithAi.Application.DTOs;

public class CreateCommentDto
{
    public string Content { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string? AuthorEmail { get; set; }
    public int PostId { get; set; }
    public int? ParentCommentId { get; set; }
}
