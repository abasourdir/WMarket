using WMarket.Modules.Base.Models.Response;

namespace WMarket.Modules.UseCases.Product.Get.Models.Response;

public class GetProductsModuleResponse : ModuleGenericResponse<List<GetProductsModuleResponseData>>;

public class GetProductsModuleResponseData
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}