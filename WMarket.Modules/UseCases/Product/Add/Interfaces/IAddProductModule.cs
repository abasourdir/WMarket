using WMarket.Modules.UseCases.Product.Add.Models.Request;
using WMarket.Modules.UseCases.Product.Add.Models.Response;

namespace WMarket.Modules.UseCases.Product.Add.Interfaces;

public interface IAddProductModule : IModule<AddProductModuleRequest, AddProductModuleResponse>
{
}