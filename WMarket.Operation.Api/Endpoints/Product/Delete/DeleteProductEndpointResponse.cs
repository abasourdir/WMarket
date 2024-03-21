using System.Text.Json.Serialization;
using WMarket.Common.Api.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.Delete;

public class DeleteProductEndpointResponse : BaseResponse<DeleteProductEndpointResponseData>;

public class DeleteProductEndpointResponseData
{
    [JsonPropertyName("id")] 
    public long Id { get; set; }
}