using BlogWithAi.Application.DTOs;
using BlogWithAi.Application.Interfaces;
using BlogWithAi.Domain.Entities;
using BlogWithAi.Domain.Interfaces;

namespace BlogWithAi.Application.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int postId)
    {
        var comments = await _commentRepository.GetByPostIdAsync(postId);
        return comments.Select(MapToDto);
    }

    public async Task<IEnumerable<CommentDto>> GetApprovedCommentsByPostIdAsync(int postId)
    {
        var comments = await _commentRepository.GetApprovedByPostIdAsync(postId);
        return comments.Select(MapToDto);
    }

    public async Task<CommentDto> CreateCommentAsync(CreateCommentDto createCommentDto)
    {
        var comment = new Comment
        {
            Content = createCommentDto.Content,
            AuthorName = createCommentDto.AuthorName,
            AuthorEmail = createCommentDto.AuthorEmail,
            PostId = createCommentDto.PostId,
            ParentCommentId = createCommentDto.ParentCommentId,
            IsApproved = false,
            CreatedAt = DateTime.UtcNow
        };

        var createdComment = await _commentRepository.AddAsync(comment);
        return MapToDto(createdComment);
    }

    public async Task ApproveCommentAsync(int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null)
            throw new KeyNotFoundException($"Comment with id {id} not found");

        comment.IsApproved = true;
        await _commentRepository.UpdateAsync(comment);
    }

    public async Task DeleteCommentAsync(int id)
    {
        await _commentRepository.DeleteAsync(id);
    }

    private static CommentDto MapToDto(Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            AuthorName = comment.AuthorName,
            AuthorEmail = comment.AuthorEmail,
            IsApproved = comment.IsApproved,
            CreatedAt = comment.CreatedAt,
            PostId = comment.PostId,
            ParentCommentId = comment.ParentCommentId,
            Replies = comment.Replies.Select(MapToDto).ToList()
        };
    }
}
