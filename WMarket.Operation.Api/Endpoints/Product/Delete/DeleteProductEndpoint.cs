using FastEndpoints;
using WMarket.Modules.UseCases.Product.Delete.Interfaces;
using WMarket.Modules.UseCases.Product.Delete.Models.Request;
using IMapper = MapsterMapper.IMapper;

namespace WMarket.Operation.Api.Endpoints.Product.Delete;

public class DeleteProductEndpoint : Endpoint<DeleteProductEndpointRequest, DeleteProductEndpointResponse>
{
    private readonly IMapper _mapper;
    private readonly IDeleteProductModule _module;

    public DeleteProductEndpoint(
        IMapper mapper,
        IDeleteProductModule module)
    {
        _mapper = mapper;
        _module = module;
    }

    public override void Configure()
    {
        Delete("/product/delete");
        Version(1);
        AllowAnonymous();
        Summary(s => s.Summary = "Delete product");
    }

    public override async Task HandleAsync(DeleteProductEndpointRequest req, CancellationToken ct)
    {
        var moduleRequest = _mapper.From(req).AdaptToType<DeleteProductModuleRequest>();
        var moduleResult = await _module.ExecuteAsync(moduleRequest);
        var response = _mapper.From(moduleResult).AdaptToType<DeleteProductEndpointResponse>();
        await SendAsync(response, cancellation: ct);
    }
}