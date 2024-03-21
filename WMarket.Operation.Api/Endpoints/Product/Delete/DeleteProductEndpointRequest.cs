using FastEndpoints;

namespace WMarket.Operation.Api.Endpoints.Product.Delete;

public class DeleteProductEndpointRequest
{
    [QueryParam, BindFrom("id")] 
    public long Id { get; set; }
}