using Newtonsoft.Json;

namespace BookShop.Domain.Models.Api.Books;

public class BooksCreateOrUpdateParameters
{
    /// <summary>
    /// The unique identifier of the book
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    /// The name of the book
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Unique identifiers of the authors of the book
    /// </summary>
    [JsonProperty("Author unique ")]
    public Guid[] AuthorIds { get; set; } = [];
    
    /// <summary>
    /// Description of the book
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }
}