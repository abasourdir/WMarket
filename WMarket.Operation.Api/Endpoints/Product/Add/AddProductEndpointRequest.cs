using System.Text.Json.Serialization;

namespace WMarket.Operation.Api.Endpoints.Product.Add;

public class AddProductEndpointRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}