using System.ComponentModel.DataAnnotations;
using BookShop.DbContext.Models.Books;
using BookShop.Domain.CreateOrUpdateParameters;
using BookShop.Domain.CreateOrUpdateParameters.Books;
using BookShop.Domain.Enums;
using BookShop.Domain.Response;
using BookShop.Domain.SearchParameters;
using BookShop.Domain.SearchParameters.Books;
using BookShop.Service.Interfaces;
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
    private readonly IRepositoryService<Book, BooksSearchParameters, BooksCreateOrUpdateParameters> _repositoryService;

    /// <summary>
    /// Books controller constructor
    /// </summary>
    /// <param name="logger">Logging interface</param>
    /// <param name="repositoryService">Service for books</param>
    public BooksController(ILogger<BooksController> logger,
        IRepositoryService<Book, BooksSearchParameters, BooksCreateOrUpdateParameters> repositoryService)
    {
        _logger = logger;
        _repositoryService = repositoryService;
    }

    /// <summary>
    /// Find 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    [HttpPost("find")]
    public async Task<IActionResult> Find(
        BooksSearchParameters parameters,
        CancellationToken token)
    {
        try
        {
            var result = await _repositoryService.Find(parameters, token);

            return Ok(new ResponseData(result));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseData(message: "Error occured while executing request, see details.",
                details: ex));
        }
    }

    /// <summary>
    /// Create or update book instance
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> CreateOrUpdate(
        BooksCreateOrUpdateParameters parameters,
        CancellationToken token)
    {
        try
        {
            var (instance, actionResult) = await _repositoryService.CreateOrUpdate(parameters, token);

            if (actionResult == CreateOrUpdateResult.Error)
            {
                throw new Exception($"Error processing request {nameof(CreateOrUpdate)}, see logs.");
            }

            // TODO: add action result messages
            return (actionResult == CreateOrUpdateResult.Created)
                ? CreatedAtAction(nameof(CreateOrUpdate), new ResponseData(instance))
                : Ok(new ResponseData(instance));
        }
        catch (ValidationException validationException)
        {
            return BadRequest(new ResponseData(
                message: $"Validation error processing {nameof(CreateOrUpdate)} request, see details.",
                details: validationException.Message));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseData(
                message: $"Error processing  request, see details.",
                details: ex));
        }
    }
}