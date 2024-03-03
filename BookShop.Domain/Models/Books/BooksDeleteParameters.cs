using Newtonsoft.Json;

namespace BookShop.Domain.Models.Books;

public class BooksDeleteParameters
{
    [JsonProperty("ids")]
    public Guid[] Ids { get; set; }
}