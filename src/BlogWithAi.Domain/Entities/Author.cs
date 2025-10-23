namespace BlogWithAi.Domain.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? Avatar { get; set; }
    
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
