using Mapster;
using WMarket.Modules.UseCases.Product.Update.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.Update;

public class UpdateProductEndpointMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateProductModuleResponse, UpdateProductEndpointResponse>()
            .Map(d => d.Data, s => s);
    }
}