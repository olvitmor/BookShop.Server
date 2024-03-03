using Newtonsoft.Json;

namespace BookShop.Domain.Models.Api.Books;

public class BooksDeleteParameters
{
    [JsonProperty("ids")]
    public Guid[] Ids { get; set; }
}