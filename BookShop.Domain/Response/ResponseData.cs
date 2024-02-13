
using Newtonsoft.Json;

namespace BookShop.Domain.Response;


public class ResponseData(object? content, string? message = null, object? details = null)
{
    [JsonProperty("content")]
    public object? Content { get; set; } = content;

    [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
    public string? Message { get; set; } = message;

    [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
    public object? Details { get; set; } = details;

    public ResponseData(string message) : this(null, message, null)
    {

    }

    public ResponseData(string message, object details) : this(null, message, details)
    {
        
    }
}