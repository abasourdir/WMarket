using System.Text.Json.Serialization;

namespace WMarket.Operation.Api.Endpoints.Order.Create;

public class CreateOrderEndpointRequest
{
    [JsonPropertyName("products")]
    public List<CreateOrderProductEndpointRequest> Products { get; set; }
}

public class CreateOrderProductEndpointRequest
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}