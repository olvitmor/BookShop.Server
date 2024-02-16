using System.ComponentModel.DataAnnotations;
using BookShop.Domain.Interfaces;
using Newtonsoft.Json;

namespace BookShop.Domain.Models.Books;

public class Book : BaseEntity, IHasId, IHasName, IHasDescription
{
    /// <summary>
    /// Book name
    /// </summary>
    [Required]
    [MaxLength(512)]
    [JsonProperty("name")]
    public string Name
    {
        get => _name;
        set => _name = value?.Trim('\r', '\n', '\t');
    }
    private string _name;

    /// <summary>
    /// Book description
    /// </summary>
    [MaxLength(2048)]
    [JsonProperty("description")]
    public string? Description { get; set; }
}