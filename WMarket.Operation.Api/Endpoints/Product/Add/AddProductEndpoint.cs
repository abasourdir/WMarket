using FastEndpoints;

namespace WMarket.Operation.Api.Endpoints.Product.Add;

public class AddProductEndpoint : Endpoint<AddProductEndpointRequest, AddProductEndpointResponse>
{
    public override void Configure()
    {
        Post("/product/add");
        Version(1);
        AllowAnonymous();
        Summary(s => s.Summary = "Add product");
    }

    public override Task HandleAsync(AddProductEndpointRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}