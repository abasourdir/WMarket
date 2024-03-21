using FastEndpoints;

namespace WMarket.Operation.Api.Endpoints.Product.Get;

public class GetProductsEndpointRequest
{
    [QueryParam, BindFrom("page")]
    public int? CurrentPage { get; set; }

    [QueryParam, BindFrom("limit")]
    public int Limit { get; set; }
}