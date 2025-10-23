using BlogWithAi.Application.DTOs;
using BlogWithAi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithAi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("post/{postId:int}")]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetCommentsByPost(int postId)
    {
        var comments = await _commentService.GetApprovedCommentsByPostIdAsync(postId);
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> CreateComment(CreateCommentDto createCommentDto)
    {
        var comment = await _commentService.CreateCommentAsync(createCommentDto);
        return CreatedAtAction(nameof(GetCommentsByPost), new { postId = comment.PostId }, comment);
    }

    [HttpPut("{id:int}/approve")]
    public async Task<IActionResult> ApproveComment(int id)
    {
        try
        {
            await _commentService.ApproveCommentAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        await _commentService.DeleteCommentAsync(id);
        return NoContent();
    }
}
