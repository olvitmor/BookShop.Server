using System.Text.Json.Serialization;

namespace BookShop.Domain.Response;

public class ResponseData(object? content, string? message = null, object? details = null)
{
    [JsonPropertyName("content")]
    public object? Content { get; set; } = content;

    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; } = message;

    [JsonPropertyName("details")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Details { get; set; } = details;

    public ResponseData(string message) : this(null, message, null)
    {

    }

    public ResponseData(string message, object details) : this(null, message, details)
    {
        
    }
}