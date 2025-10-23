using BlogWithAi.Application.Interfaces;
using BlogWithAi.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithAi.UI.Controllers;

public class BlogController : Controller
{
    private readonly IPostService _postService;
    private readonly ICategoryService _categoryService;
    private readonly ICommentService _commentService;

    public BlogController(
        IPostService postService,
        ICategoryService categoryService,
        ICommentService commentService)
    {
        _postService = postService;
        _categoryService = categoryService;
        _commentService = commentService;
    }

    public async Task<IActionResult> Post(string slug)
    {
        var post = await _postService.GetPostBySlugAsync(slug);
        if (post == null)
            return NotFound();

        var comments = await _commentService.GetApprovedCommentsByPostIdAsync(post.Id);
        ViewBag.Comments = comments;
        
        return View(post);
    }

    public async Task<IActionResult> Category(string slug)
    {
        var category = await _categoryService.GetCategoryBySlugAsync(slug);
        if (category == null)
            return NotFound();

        var posts = await _postService.GetPostsByCategoryAsync(category.Id);
        ViewBag.Category = category;
        
        return View(posts);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(CreateCommentDto commentDto)
    {
        if (ModelState.IsValid)
        {
            await _commentService.CreateCommentAsync(commentDto);
            return RedirectToAction(nameof(Post), new { slug = commentDto.PostId });
        }

        return RedirectToAction(nameof(Post), new { slug = commentDto.PostId });
    }
}
