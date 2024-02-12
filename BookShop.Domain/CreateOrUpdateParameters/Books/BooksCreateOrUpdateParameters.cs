using System.Linq.Expressions;
using System.Text.Json.Serialization;
using BookShop.DbContext.Models.Books;

namespace BookShop.Domain.CreateOrUpdateParameters.Books;

public class BooksCreateOrUpdateParameters
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("book")]
    public Book Book { get; set; }
}