using System.Text.Json.Serialization;

namespace WMarket.Operation.Api.Endpoints.Product.Add;

public class AddProductEndpointResponse
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}