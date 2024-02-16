using System.Linq.Expressions;
using BookShop.Domain.Extensions;
using BookShop.Domain.Models.Books;
using BookShop.Service.Interfaces;
using BookShop.Service.Interfaces.Books;

namespace BookShop.Service.Services.Books;

public class BooksRepositoryReadService : IBooksRepositoryReadService
{
    private readonly IRepository _repository;

    public BooksRepositoryReadService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Book>> Find(BooksSearchParameters parameters, CancellationToken token)
    {
        var filter = ((Expression<Func<Book, bool>>)(x => true))
            .AddAndAlsoConditionWhenTrue(parameters.Ids is not null and { Length: > 0 },
                x => parameters.Ids!.Contains(x.Id))
            .AddAndAlsoConditionWhenTrue(parameters.Names is not null and { Length: > 0 },
                x => parameters.Names!.Contains(x.Name))
            .AddAndAlsoConditionWhenTrue(parameters.Description is not null and { Length: > 0 },
                x => x.Description!.Contains(parameters.Description!));

        return await _repository.Find<Book>(filter, token);
    }

    public Task<Book> Get(BooksSearchParameters parameters, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}