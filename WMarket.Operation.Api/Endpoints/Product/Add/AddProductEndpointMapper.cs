using Mapster;
using WMarket.Modules.UseCases.Product.Add.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.Add;

public class AddProductEndpointMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddProductModuleResponse, AddProductEndpointResponse>()
            .Map(d => d.Data, s => s);
    }
}