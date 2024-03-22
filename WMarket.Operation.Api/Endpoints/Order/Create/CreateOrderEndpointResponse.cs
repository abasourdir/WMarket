using System.Text.Json.Serialization;
using WMarket.Common.Api.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Order.Create;

public class CreateOrderEndpointResponse : BaseResponse<CreateOrderEndpointResponseData>;

public class CreateOrderEndpointResponseData
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("deliveryDate")]
    public DateTime DeliveryDate { get; set; }
}