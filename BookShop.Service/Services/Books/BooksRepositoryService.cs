using BookShop.DbContext.Models.Books;
using BookShop.Domain.CreateOrUpdateParameters;
using BookShop.Domain.CreateOrUpdateParameters.Books;
using BookShop.Domain.SearchParameters.Books;
using BookShop.Service.Interfaces;
using BookShop.Settings;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Service.Services.Books;

public class BooksRepositoryService : IRepositoryService<Book, BooksSearchParameters, BooksCreateOrUpdateParameters>
{
    private readonly SettingsProvider _settingsProvider;
    private readonly IDbContextService _dbContextService;
    
    public BooksRepositoryService(SettingsProvider settingsProvider, IDbContextService dbContextService)
    {
        _settingsProvider = settingsProvider;
        _dbContextService = dbContextService;
    }
    
    public async Task<ICollection<Book>> Find(BooksSearchParameters parameters, CancellationToken token)
    {
        var expression = parameters.GetExpression();
        
        await using var dbContext = _dbContextService.GetDbContext();

        return await dbContext.Books
            .Where(expression)
            .ToListAsync(token);
    }

    public Task<Book> Get(BooksSearchParameters parameters, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<(Book, bool)> CreateOrUpdate(BooksCreateOrUpdateParameters parameters, CancellationToken token)
    {
        if (parameters == null)
            throw new ArgumentNullException();
        
        await using var dbContext = _dbContextService.GetDbContext();

        var bookInDb = await dbContext.Books.FindAsync(new object?[] { parameters.Id, token }, cancellationToken: token);

        var needToCreate = bookInDb == null;

        if (!needToCreate)
        {
            // update
            bookInDb?.Apply(parameters.Book);
        }
        else
        {
            // create
            bookInDb = parameters.Book;
            await dbContext.Books.AddAsync(bookInDb, token);
        }

        await dbContext.SaveChangesAsync(token);

        return (bookInDb, needToCreate);
    }

    public Task<Guid> Delete(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}