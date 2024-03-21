using FastEndpoints;
using WMarket.Modules.UseCases.Product.Update.Interfaces;
using WMarket.Modules.UseCases.Product.Update.Models.Request;
using IMapper = MapsterMapper.IMapper;

namespace WMarket.Operation.Api.Endpoints.Product.Update;

public class UpdateProductEndpoint : Endpoint<UpdateProductEndpointRequest, UpdateProductEndpointResponse>
{
    private readonly IMapper _mapper;
    private readonly IUpdateProductModule _module;

    public UpdateProductEndpoint(
        IMapper mapper,
        IUpdateProductModule module)
    {
        _mapper = mapper;
        _module = module;
    }
   
    public override void Configure()
    {
        Patch("/product/update");
        Version(1);
        AllowAnonymous();
        Summary(s => s.Summary = "Update product");
    }

    public override async Task HandleAsync(UpdateProductEndpointRequest req, CancellationToken ct)
    {
        var moduleRequest = _mapper.From(req).AdaptToType<UpdateProductModuleRequest>();
        var moduleResult = await _module.ExecuteAsync(moduleRequest);
        var response = _mapper.From(moduleResult).AdaptToType<UpdateProductEndpointResponse>();
        await SendAsync(response, cancellation: ct);
    }
}