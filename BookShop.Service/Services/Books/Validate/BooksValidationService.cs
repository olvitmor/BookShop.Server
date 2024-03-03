using BookShop.Domain.Models.Api.Books;
using BookShop.Domain.Models.DbContext;
using BookShop.Service.Interfaces.Books;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace BookShop.Service.Services.Books.Validate;

public class BooksValidationService : IBooksValidationService
{
    private readonly ILogger<BooksValidationService> _logger;
    private readonly IValidator<BooksCreateOrUpdateParameters> _validator;
    
    public BooksValidationService(ILogger<BooksValidationService> logger,
        IValidator<BooksCreateOrUpdateParameters> validator)
    {
        _logger = logger;
        _validator = validator;
    }

    public async Task ThrowIfNotValid(BooksCreateOrUpdateParameters model, CancellationToken token)
    {
        await _validator.ValidateAndThrowAsync(model, token);

        return;
    }

    public async Task<bool> IsValid(BooksCreateOrUpdateParameters model, CancellationToken token)
    {
        var validationResult = await _validator.ValidateAsync(model, token);
        return validationResult.IsValid;
    }
}