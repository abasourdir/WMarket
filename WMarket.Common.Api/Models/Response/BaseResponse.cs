using System.Text.Json.Serialization;

namespace WMarket.Common.Api.Models.Response;

public class BaseResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ErrorResponse? Error { get; set; }
}