using FastEndpoints;
using WMarket.Modules.UseCases.Order.Create.Interfaces;
using WMarket.Modules.UseCases.Order.Create.Models.Request;
using IMapper = MapsterMapper.IMapper;

namespace WMarket.Operation.Api.Endpoints.Order.Create;

public class CreateOrderEndpoint : Endpoint<CreateOrderEndpointRequest, CreateOrderEndpointResponse>
{
    private readonly IMapper _mapper;
    private readonly ICreateOrderModule _module;

    public CreateOrderEndpoint(
        IMapper mapper,
        ICreateOrderModule module)
    {
        _mapper = mapper;
        _module = module;
    }

    public override void Configure()
    {
        Post("/order/create");
        Version(1);
        AllowAnonymous();
        Summary(s => s.Summary = "Place an order");
    }

    public override async Task HandleAsync(CreateOrderEndpointRequest req, CancellationToken ct)
    {
        var moduleRequest = _mapper.From(req).AdaptToType<CreateOrderModuleRequest>();
        var moduleResult = await _module.ExecuteAsync(moduleRequest);
        var response = _mapper.From(moduleResult).AdaptToType<CreateOrderEndpointResponse>();
        await SendAsync(response, cancellation: ct);
    }
}