using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BookShop.Domain.Models;

[DataContract]
public class BaseEntity
{
    [Required]
    [DataMember(Name="id")]
    [JsonProperty("id")]
    public Guid Id { get; set; }
}