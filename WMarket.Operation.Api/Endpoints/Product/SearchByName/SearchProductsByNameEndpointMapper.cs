using Mapster;
using WMarket.Modules.UseCases.Product.SearchByName.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.SearchByName;

public class SearchProductsByNameEndpointMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SearchProductsByNameModuleResponse, SearchProductsByNameEndpointResponse>()
            .Map(d => d.Data, s => s.Data);
    }
}