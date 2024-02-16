using BookShop.Domain.Interfaces;
using Newtonsoft.Json;

namespace BookShop.Domain.Models.Books;

public class BooksDeleteParameters : IHasIds
{
    [JsonProperty("ids")]
    public Guid[]? Ids { get; set; }
}