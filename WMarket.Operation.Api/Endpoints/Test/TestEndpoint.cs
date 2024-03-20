using FastEndpoints;

namespace WMarket.Operation.Api.Endpoints.Test;

public class TestEndpoint : Endpoint<TestEndpointRequest, TestEndpointResponse>
{
    public override void Configure()
    {
        Get("/test");
        AllowAnonymous();
    }

    public override async Task HandleAsync(TestEndpointRequest req, CancellationToken ct)
    {
        var response = new TestEndpointResponse
        {
            Response = $"Hello, {req.Name}"
        };
        await SendAsync(response, cancellation: ct);
    }
}