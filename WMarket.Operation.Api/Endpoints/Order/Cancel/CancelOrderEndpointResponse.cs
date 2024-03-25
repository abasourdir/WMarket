using System.Text.Json.Serialization;
using WMarket.Common.Api.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Order.Cancel;

public class CancelOrderEndpointResponse : BaseResponse<CancelOrderEndpointResponseData>;

public class CancelOrderEndpointResponseData
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}