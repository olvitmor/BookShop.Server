using System.Text.Json.Serialization;

namespace BookShop.Domain.Interfaces;

public interface IHasIds
{
    public Guid[]? Ids { get; set; }
}