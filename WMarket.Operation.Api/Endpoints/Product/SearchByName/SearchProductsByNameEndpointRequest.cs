using FastEndpoints;

namespace WMarket.Operation.Api.Endpoints.Product.SearchByName;

public class SearchProductsByNameEndpointRequest
{
    [QueryParam, BindFrom("name")]
    public string? Name { get; set; }
    
    [QueryParam, BindFrom("page")]
    public int? CurrentPage { get; set; }

    [QueryParam, BindFrom("limit")]
    public int Limit { get; set; }
}