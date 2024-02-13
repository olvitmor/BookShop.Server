using System.Text.Json.Serialization;
using BookShop.DbContext.Models.Books;

namespace BookShop.Domain.CreateOrUpdateParameters.Books;

public class BooksCreateOrUpdateParameters
{
    [JsonPropertyName("book")]
    public Book Book { get; set; }
}