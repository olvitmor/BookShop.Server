using Newtonsoft.Json;

namespace BookShop.Domain.Models.Api.Books;

public class BooksSearchParameters
{
    [JsonProperty("ids")]
    public Guid[]? Ids { get; set; }
    
    [JsonProperty("names")]
    public string[]? Names { get; set; }
    
    [JsonProperty("description")]
    public string? Description { get; set; }
}