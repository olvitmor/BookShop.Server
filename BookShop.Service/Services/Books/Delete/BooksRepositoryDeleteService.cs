using System.Linq.Expressions;
using BookShop.Domain.Enums;
using BookShop.Domain.Extensions;
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

    public async Task<(ICollection<Guid>?, DeleteResult)> Delete(BooksDeleteParameters parameters, CancellationToken token)
    {
        _logger.LogInformation($"{nameof(Delete)} request for {nameof(Book)} entity");
        
        var filter = ((Expression<Func<Book, bool>>)(x => true))
            .AddAndAlsoConditionWhenTrue(parameters.Ids is not null and { Length: > 0 },
                x => parameters.Ids!.Contains(x.Id));

        return await _repository.Delete<Book>(filter, token);
    }
}