using System.Text.Json.Serialization;
using WMarket.Common.Models.Enum;

namespace WMarket.Common.Api.Models.Response;

public class ErrorResponse
{
    [JsonPropertyName("errorCode")]
    public ErrorCode ErrorCode { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}