using AutoMapper;
using BookShop.Domain.Enums;
using BookShop.Domain.Models.Api.Books;
using BookShop.Domain.Models.DbContext;
using BookShop.Service.Interfaces;
using BookShop.Service.Interfaces.Books;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services.Books.CreateOrUpdate;

public class BooksRepositoryCreateOrUpdateService : IBooksRepositoryCreateOrUpdateService
{
    private readonly IRepository _repository;
    private readonly IBooksValidationService _validationService;
    private readonly ILogger<BooksRepositoryCreateOrUpdateService> _logger;
    private readonly IMapper _mapper;

    public BooksRepositoryCreateOrUpdateService(
        ILogger<BooksRepositoryCreateOrUpdateService> logger,
        IBooksValidationService validationService, 
        IRepository repository,
        IMapper mapper)
    {
        _validationService = validationService;
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<(Book?, CreateOrUpdateResult)> CreateOrUpdate(BooksCreateOrUpdateParameters parameters,
        CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        
        await _validationService.ThrowIfNotValid(parameters, token);

        var book = _mapper.Map<Book>(parameters);
        
        return await _repository.CreateOrUpdate(book.Id, book, token);
    }
}