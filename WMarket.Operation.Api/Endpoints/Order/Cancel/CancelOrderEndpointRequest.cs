using System.Text.Json.Serialization;

namespace WMarket.Operation.Api.Endpoints.Order.Cancel;

public class CancelOrderEndpointRequest
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}