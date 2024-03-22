using Mapster;
using WMarket.Modules.UseCases.Order.Create.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Order.Create;

public class CreateOrderEndpointMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderModuleResponse, CreateOrderEndpointResponse>()
            .Map(d => d.Data, s => s);
    }
}
