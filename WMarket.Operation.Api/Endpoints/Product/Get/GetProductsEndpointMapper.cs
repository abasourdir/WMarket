using Mapster;
using WMarket.Modules.UseCases.Product.Get.Models.Response;

namespace WMarket.Operation.Api.Endpoints.Product.Get;

public class GetProductsEndpointMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetProductsModuleResponse, GetProductsEndpointResponse>()
            .Map(d => d.Data, s => s.Data);
    }
}