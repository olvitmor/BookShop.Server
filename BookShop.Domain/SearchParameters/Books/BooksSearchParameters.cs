using System.Text.Json.Serialization;

namespace BookShop.Domain.SearchParameters.Books;

public class BooksSearchParameters
{
    [JsonPropertyName("ids")]
    public string[]? Ids { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}