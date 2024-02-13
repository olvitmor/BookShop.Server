using System.Linq.Expressions;
using BookShop.DbContext.Models.Books;
using BookShop.Domain.CreateOrUpdateParameters.Books;
using BookShop.Domain.Enums;
using BookShop.Domain.Extensions;
using BookShop.Domain.SearchParameters.Books;
using BookShop.Service.Interfaces;

namespace BookShop.Service.Services.Books;

public class BooksRepositoryReadReadService : IRepositoryReadService<Book, BooksSearchParameters, BooksCreateOrUpdateParameters>
{
    private readonly IValidationService<Book> _validationService;
    private readonly IRepository _repository;

    public BooksRepositoryReadReadService(
        IValidationService<Book> validationService,
        IRepository repository)
    {
        _validationService = validationService;
        _repository = repository;
    }

    public async Task<ICollection<Book>> Find(BooksSearchParameters parameters, CancellationToken token)
    {
        var filter = ((Expression<Func<Book, bool>>)(x => true))
            .AddAndAlsoConditionWhenTrue(parameters.Ids is not null and { Length: > 0 },
                x => parameters.Ids!.Contains(x.Id))
            .AddAndAlsoConditionWhenTrue(parameters.Name is not null and { Length: > 0 },
                x => x.Name == parameters.Name)
            .AddAndAlsoConditionWhenTrue(parameters.Description is not null and { Length: > 0 },
                x => x.Description!.Contains(parameters.Description!));

        return await _repository.Find<Book>(filter, token);
    }

    public Task<Book> Get(BooksSearchParameters parameters, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<(Book?, CreateOrUpdateResult)> CreateOrUpdate(BooksCreateOrUpdateParameters parameters,
        CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        
        _validationService.Validate(parameters.Book);

        return await _repository.CreateOrUpdate(parameters.Book.Id, parameters.Book, token);
    }

    public Task<Guid> Delete(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}