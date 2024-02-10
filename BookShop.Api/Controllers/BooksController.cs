using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers;

/// <summary>
/// Books controller
/// </summary>
[ApiController]
[Route("/books")]
public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;

    /// <summary>
    /// Books controller constructor
    /// </summary>
    /// <param name="logger">Logging interface</param>
    public BooksController(ILogger<BooksController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get all books
    /// </summary>
    /// <param name="token">Cancellation token</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetBooks(CancellationToken token)
    {
        return Ok("Soon...");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(CancellationToken token, string id)
    {
        return Ok($"book {id}");
    }
}