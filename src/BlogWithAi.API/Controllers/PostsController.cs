using BlogWithAi.Application.DTOs;
using BlogWithAi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithAi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("published")]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetPublishedPosts()
    {
        var posts = await _postService.GetPublishedPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PostDto>> GetPostById(int id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null)
            return NotFound();

        return Ok(post);
    }

    [HttpGet("slug/{slug}")]
    public async Task<ActionResult<PostDto>> GetPostBySlug(string slug)
    {
        var post = await _postService.GetPostBySlugAsync(slug);
        if (post == null)
            return NotFound();

        await _postService.IncrementViewCountAsync(post.Id);
        return Ok(post);
    }

    [HttpGet("category/{categoryId:int}")]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetPostsByCategory(int categoryId)
    {
        var posts = await _postService.GetPostsByCategoryAsync(categoryId);
        return Ok(posts);
    }

    [HttpGet("tag/{tagId:int}")]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetPostsByTag(int tagId)
    {
        var posts = await _postService.GetPostsByTagAsync(tagId);
        return Ok(posts);
    }

    [HttpGet("author/{authorId:int}")]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetPostsByAuthor(int authorId)
    {
        var posts = await _postService.GetPostsByAuthorAsync(authorId);
        return Ok(posts);
    }

    [HttpPost]
    public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto createPostDto)
    {
        var post = await _postService.CreatePostAsync(createPostDto);
        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePost(int id, CreatePostDto updatePostDto)
    {
        try
        {
            await _postService.UpdatePostAsync(id, updatePostDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _postService.DeletePostAsync(id);
        return NoContent();
    }
}
