using Mapster;
using WMarket.Modules.UseCases.Order.Cancel.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Order.Cancel;

public class CancelOrderEndpointMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CancelOrderModuleResponse, CancelOrderEndpointResponse>()
            .Map(d => d.Data, s => s);
    }
}