using FastEndpoints;
using WMarket.Modules.UseCases.Product.Add.Interfaces;
using WMarket.Modules.UseCases.Product.Add.Models.Request;
using IMapper = MapsterMapper.IMapper;

namespace WMarket.Operation.Api.Endpoints.Product.Add;

public class AddProductEndpoint : Endpoint<AddProductEndpointRequest, AddProductEndpointResponse>
{
    private readonly IMapper _mapper;
    private readonly IAddProductModule _module;

    public AddProductEndpoint(
        IMapper mapper,
        IAddProductModule module)
    {
        _mapper = mapper;
        _module = module;
    }
    
    public override void Configure()
    {
        Post("/product/add");
        Version(1);
        AllowAnonymous();
        Summary(s => s.Summary = "Add product");
    }

    public override async Task HandleAsync(AddProductEndpointRequest req, CancellationToken ct)
    {
        var moduleRequest = _mapper.From(req).AdaptToType<AddProductModuleRequest>();
        var moduleResult = await _module.ExecuteAsync(moduleRequest);
        var response = _mapper.From(moduleResult).AdaptToType<AddProductEndpointResponse>();
        await SendAsync(response, cancellation: ct);
    }
}