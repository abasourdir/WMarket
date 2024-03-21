using WMarket.Modules.UseCases.Product.Get.Models.Request;
using WMarket.Modules.UseCases.Product.Get.Models.Response;

namespace WMarket.Modules.UseCases.Product.Get.Interfaces;

public interface IGetProductsModule : IModule<GetProductsModuleRequest, GetProductsModuleResponse>;