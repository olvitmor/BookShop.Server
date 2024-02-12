using System.Data.Common;
using BookShop.DbContext.Models.Books;
using BookShop.Domain.CreateOrUpdateParameters;
using BookShop.Domain.CreateOrUpdateParameters.Books;
using BookShop.Domain.Enums;
using BookShop.Domain.SearchParameters.Books;
using BookShop.Service.Interfaces;
using BookShop.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services.Books;

public class BooksRepositoryService : IRepositoryService<Book, BooksSearchParameters, BooksCreateOrUpdateParameters>
{
    private readonly SettingsProvider _settingsProvider;
    private readonly IDbContextService _dbContextService;
    private readonly IValidationService<Book> _validationService;
    private readonly ILogger<BooksRepositoryService> _logger;
    private readonly IRepository _repository;
    

    public BooksRepositoryService(SettingsProvider settingsProvider,
        IDbContextService dbContextService,
        IValidationService<Book> validationService,
        ILogger<BooksRepositoryService> logger,
        IRepository repository)
    {
        _settingsProvider = settingsProvider;
        _dbContextService = dbContextService;
        _validationService = validationService;
        _logger = logger;
        _repository = repository;
    }

    public async Task<ICollection<Book>> Find(BooksSearchParameters parameters, CancellationToken token)
    {
        var resultList = new List<Book>();

        var isSuccess = await _repository.ExecuteAsync<Book>(FindBooksFunc);

        return resultList;

        async Task FindBooksFunc()
        {
            var expression = parameters.GetExpression();
            await using var dbContext = await _dbContextService.CreateDbContext();

            resultList = await dbContext.Books.Where(expression)
                .ToListAsync(token);
        }
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

        Book? instance = null;
        var actionResult = CreateOrUpdateResult.None;

        var isSuccess = await _repository.ExecuteAsync<Book>(BooksCreateOrUpdateFunc);

        if (!isSuccess)
            actionResult = CreateOrUpdateResult.Error;

        return (instance, actionResult);

        async Task BooksCreateOrUpdateFunc()
        {
            await using var dbContext = await _dbContextService.CreateDbContext();

            var existingBook = await dbContext.Books.FindAsync(new object?[] { parameters.Id, token }, cancellationToken: token);

            var needToCreate = existingBook == null;

            if (needToCreate)
            {
                await dbContext.Books.AddAsync(parameters.Book, token);
                actionResult = CreateOrUpdateResult.Created;
            }
            else
            {
                existingBook?.Apply(parameters.Book);
                actionResult = CreateOrUpdateResult.Updated;
            }

            await dbContext.SaveChangesAsync(token);

            instance = existingBook;
        }
    }

    public Task<Guid> Delete(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}