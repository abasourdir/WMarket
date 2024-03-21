namespace WMarket.Modules.UseCases.Product.Get.Models.Request;

public class GetProductsModuleRequest
{
    public int? CurrentPage { get; set; }

    public int Limit { get; set; }
}