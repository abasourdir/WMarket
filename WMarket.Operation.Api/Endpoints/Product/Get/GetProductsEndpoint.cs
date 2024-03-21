using FastEndpoints;
using WMarket.Modules.UseCases.Product.Get.Interfaces;
using WMarket.Modules.UseCases.Product.Get.Models.Request;
using IMapper = MapsterMapper.IMapper;

namespace WMarket.Operation.Api.Endpoints.Product.Get;

public class GetProductsEndpoint : Endpoint<GetProductsEndpointRequest, GetProductsEndpointResponse>
{
    private readonly IMapper _mapper;
    private readonly IGetProductsModule _module;

    public GetProductsEndpoint(
        IMapper mapper,
        IGetProductsModule module)
    {
        _mapper = mapper;
        _module = module;
    }

    public override void Configure()
    {
        Get("/product/list");
        Version(1);
        AllowAnonymous();
        Summary(s => s.Summary = "Получение списка продуктов");
    }

    public override async Task HandleAsync(GetProductsEndpointRequest req, CancellationToken ct)
    {
        var moduleRequest = _mapper.From(req).AdaptToType<GetProductsModuleRequest>();
        var moduleResult = await _module.ExecuteAsync(moduleRequest);
        var response = _mapper.From(moduleResult).AdaptToType<GetProductsEndpointResponse>();
        await SendAsync(response, cancellation: ct);
    }
}