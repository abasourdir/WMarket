using FastEndpoints;

namespace WMarket.Operation.Api.Endpoints.Test;

public class TestEndpointRequest
{
    [QueryParam, BindFrom("name")]
    public string Name { get; set; }
}