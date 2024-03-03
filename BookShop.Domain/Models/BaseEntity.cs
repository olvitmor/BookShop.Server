using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using BookShop.Domain.Interfaces;
using Newtonsoft.Json;

namespace BookShop.Domain.Models;

[DataContract]
public class BaseEntity : IHasId
{
    [Required]
    [DataMember(Name = "id")]
    [JsonProperty("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
}