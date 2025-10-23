using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogWithAi.UI.Models;
using BlogWithAi.Application.Interfaces;

namespace BlogWithAi.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPostService _postService;

    public HomeController(ILogger<HomeController> logger, IPostService postService)
    {
        _logger = logger;
        _postService = postService;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _postService.GetPublishedPostsAsync();
        return View(posts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
