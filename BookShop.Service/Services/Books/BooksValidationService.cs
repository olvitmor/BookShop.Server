using System.ComponentModel.DataAnnotations;
using BookShop.Domain.Models.Books;
using BookShop.Service.Interfaces.Books;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services.Books;

public class BooksValidationService : IBooksValidationService
{
    private readonly ILogger<BooksValidationService> _logger;
    
    public BooksValidationService(ILogger<BooksValidationService> logger)
    {
        _logger = logger;
    }
    
    public void ThrowIfNotValid(Book model)
    {
        ValidateFunc(model);   
    }

    public bool IsValid(Book model)
    {
        try
        {
            ValidateFunc(model);
            return true;
        }
        catch(ValidationException exception)
        {
            _logger.LogError(exception.Message);
        }

        return false;
    }

    private void ValidateFunc(Book model)
    {
        if (string.IsNullOrEmpty(model.Name))
            throw new ValidationException(nameof(model.Name));
    }
}