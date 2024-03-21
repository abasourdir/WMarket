using System.Text.Json.Serialization;
using WMarket.Common.Api.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.Get;

public class GetProductsEndpointResponse : BaseResponse<List<GetProductsEndpointResponseData>>
{
}

public class GetProductsEndpointResponseData 
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}