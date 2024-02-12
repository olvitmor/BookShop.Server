using BookShop.DbContext.Models.Books;
using BookShop.Domain.SearchParameters;
using BookShop.Domain.UpdateParameters;
using BookShop.Service.Interfaces;
using BookShop.Settings;

namespace BookShop.Service.Services.Books;

public class BooksRepositoryService : IRepositoryService<Book, BooksSearchParameters, BooksCreateOrUpdateParameters>
{
    private readonly SettingsProvider _settingsProvider;
    
    public BooksRepositoryService(SettingsProvider settingsProvider)
    {
        _settingsProvider = settingsProvider;
    }
    
    public async Task<ICollection<Book>> Find(BooksSearchParameters parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> Get(BooksSearchParameters parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<(Book, bool)> CreateOrUpdate(Book model, BooksCreateOrUpdateParameters parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}