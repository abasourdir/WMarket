using System.Text.Json.Serialization;
using WMarket.Common.Api.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.SearchByName;

public class SearchProductsByNameEndpointResponse : BaseResponse<List<SearchProductsEndpointResponseData>>;

public class SearchProductsEndpointResponseData 
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}