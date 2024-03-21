using System.Text.Json.Serialization;
using WMarket.Common.Api.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.Add;

public class AddProductEndpointResponse : BaseResponse<AddProductEndpointResponseData>
{
}

public class AddProductEndpointResponseData
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}