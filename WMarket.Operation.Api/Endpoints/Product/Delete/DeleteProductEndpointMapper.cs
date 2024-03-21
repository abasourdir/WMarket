using Mapster;
using WMarket.Modules.UseCases.Product.Delete.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.Delete;

public class DeleteProductEndpointMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DeleteProductModuleResponse, DeleteProductEndpointResponse>()
            .Map(d => d.Data, s => s);
    }
}