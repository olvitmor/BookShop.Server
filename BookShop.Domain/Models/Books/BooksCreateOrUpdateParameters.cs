using Newtonsoft.Json;

namespace BookShop.Domain.Models.Books;

public class BooksCreateOrUpdateParameters
{
    [JsonProperty("book")]
    public Book Book { get; set; }
}