using FastEndpoints;
using WMarket.Modules.UseCases.Order.Cancel.Interfaces;
using WMarket.Modules.UseCases.Order.Cancel.Models.Request;
using IMapper = MapsterMapper.IMapper;

namespace WMarket.Operation.Api.Endpoints.Order.Cancel;

public class CancelOrderEndpoint : Endpoint<CancelOrderEndpointRequest, CancelOrderEndpointResponse>
{
    private readonly IMapper _mapper;
    private readonly ICancelOrderModule _module;

    public CancelOrderEndpoint(
        IMapper mapper,
        ICancelOrderModule module)
    {
        _mapper = mapper;
        _module = module;
    }

    public override void Configure()
    {
        Post("/order/cancel");
        Version(1);
        AllowAnonymous();
        Summary(s => s.Summary = "Cancel order");
    }

    public override async Task HandleAsync(CancelOrderEndpointRequest req, CancellationToken ct)
    {
        var moduleRequest = _mapper.From(req).AdaptToType<CancelOrderModuleRequest>();
        var moduleResult = await _module.ExecuteAsync(moduleRequest);
        var response = _mapper.From(moduleResult).AdaptToType<CancelOrderEndpointResponse>();
        await SendAsync(response, cancellation: ct);
    }
}