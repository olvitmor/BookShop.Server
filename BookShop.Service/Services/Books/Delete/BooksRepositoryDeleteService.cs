using BookShop.Domain.Models.Books;
using BookShop.Service.Interfaces;
using BookShop.Service.Interfaces.Books;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services.Books.Delete;

public class BooksRepositoryDeleteService : IBooksRepositoryDeleteService
{
    private readonly ILogger<BooksRepositoryDeleteService> _logger;
    private readonly IRepository _repository;

    public BooksRepositoryDeleteService(
        ILogger<BooksRepositoryDeleteService> logger,
        IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public Task<Guid> Delete(BooksDeleteParameters parameters, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<List<Guid>> DeleteBulk(BooksDeleteParameters parameters, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}