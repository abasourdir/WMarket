using FastEndpoints;
using WMarket.Modules.UseCases.Product.SearchByName.Interfaces;
using WMarket.Modules.UseCases.Product.SearchByName.Models.Request;
using IMapper = MapsterMapper.IMapper;

namespace WMarket.Operation.Api.Endpoints.Product.SearchByName;

public class SearchProductsByNameEndpoint : Endpoint<SearchProductsByNameEndpointRequest, SearchProductsByNameEndpointResponse>
{
    private readonly IMapper _mapper;
    private readonly ISearchProductsByNameModule _module;

    public SearchProductsByNameEndpoint(
        IMapper mapper,
        ISearchProductsByNameModule module)
    {
        _mapper = mapper;
        _module = module;
    }

    public override void Configure()
    {
        Get("/product/by-name");
        Version(1);
        AllowAnonymous();
        Summary(s => s.Summary = "Get list of products by name");
    }

    public override async Task HandleAsync(SearchProductsByNameEndpointRequest req, CancellationToken ct)
    {
        var moduleRequest = _mapper.From(req).AdaptToType<SearchProductsByNameModuleRequest>();
        var moduleResult = await _module.ExecuteAsync(moduleRequest);
        var response = _mapper.From(moduleResult).AdaptToType<SearchProductsByNameEndpointResponse>();
        await SendAsync(response, cancellation: ct);
    }
}