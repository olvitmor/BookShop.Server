using System.ComponentModel.DataAnnotations;
using System.Text;
using BookShop.Domain.Enums;
using BookShop.Domain.Extensions;
using BookShop.Domain.Models.Api;
using BookShop.Domain.Models.Api.Books;
using BookShop.Domain.Response;
using BookShop.Service.Interfaces.Books;
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
    private readonly IBooksRepositoryCreateOrUpdateService _createOrUpdateOrUpdateService;
    private readonly IBooksRepositoryReadService _readService;
    private readonly IBooksRepositoryDeleteService _deleteService;

    /// <summary>
    /// Books controller constructor
    /// </summary>
    /// <param name="logger">Logging interface</param>
    /// <param name="createOrUpdateOrUpdateService"></param>
    /// <param name="readService"></param>
    /// <param name="deleteService"></param>
    public BooksController(
        ILogger<BooksController> logger,
        IBooksRepositoryCreateOrUpdateService createOrUpdateOrUpdateService,
        IBooksRepositoryReadService readService,
        IBooksRepositoryDeleteService deleteService)
    {
        _logger = logger;
        _createOrUpdateOrUpdateService = createOrUpdateOrUpdateService;
        _readService = readService;
        _deleteService = deleteService;
    }

    /// <summary>
    /// Find books
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
            var result = await _readService.Find(parameters, token);

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
            var (instance, actionResult) = await _createOrUpdateOrUpdateService.CreateOrUpdate(parameters, token);

            if (actionResult == CreateOrUpdateResult.Error)
            {
                throw new Exception($"Error processing request {nameof(CreateOrUpdate)}, see logs.");
            }

            // TODO: add action result messages
            return (actionResult == CreateOrUpdateResult.Created)
                ? CreatedAtAction(nameof(CreateOrUpdate), new ResponseData(instance))
                : Ok(new ResponseData(instance));
        }
        catch (FluentValidation.ValidationException validationException)
        {
            return BadRequest(new ResponseData(
                message: $"Validation error processing {nameof(CreateOrUpdate)} request, see details.",
                details: validationException.ToSimpleStringArray()));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseData(
                message: $"Error processing  request, see details.",
                details: ex));
        }
    }

    /// <summary>
    /// Delete books
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpDelete]
    public async Task<IActionResult> Delete(BooksDeleteParameters parameters, CancellationToken token)
    {
        try
        {
            var (deletedIds, actionResult) = await _deleteService.Delete(parameters, token);

            if (actionResult == DeleteResult.Error)
            {
                throw new Exception($"Error processing request {nameof(CreateOrUpdate)}, see logs.");
            }

            return Ok(new ResponseData(deletedIds));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseData(
                message: $"Error processing  request, see details.",
                details: ex));
        }
    }
}