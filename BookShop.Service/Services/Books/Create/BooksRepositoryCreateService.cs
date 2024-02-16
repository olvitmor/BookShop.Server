using BookShop.Domain.Enums;
using BookShop.Domain.Models.Books;
using BookShop.Service.Interfaces;
using BookShop.Service.Interfaces.Books;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services.Books.Create;

public class BooksRepositoryCreateService : IBooksRepositoryCreateService
{
    private readonly IRepository _repository;
    private readonly IBooksValidationService _validationService;
    private readonly ILogger<BooksRepositoryCreateService> _logger;

    public BooksRepositoryCreateService(
        ILogger<BooksRepositoryCreateService> logger,
        IBooksValidationService validationService, 
        IRepository repository)
    {
        _validationService = validationService;
        _repository = repository;
        _logger = logger;
    }
    
    public async Task<(Book?, CreateOrUpdateResult)> CreateOrUpdate(BooksCreateOrUpdateParameters parameters,
        CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        
        _validationService.ThrowIfNotValid(parameters.Book);
    
        return await _repository.CreateOrUpdate(parameters.Book.Id, parameters.Book, token);
    }
}