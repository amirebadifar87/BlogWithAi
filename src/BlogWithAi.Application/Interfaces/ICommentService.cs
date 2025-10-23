using BlogWithAi.Application.DTOs;

namespace BlogWithAi.Application.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int postId);
    Task<IEnumerable<CommentDto>> GetApprovedCommentsByPostIdAsync(int postId);
    Task<CommentDto> CreateCommentAsync(CreateCommentDto createCommentDto);
    Task ApproveCommentAsync(int id);
    Task DeleteCommentAsync(int id);
}
