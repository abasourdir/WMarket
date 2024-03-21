using WMarket.Modules.UseCases.Product.Update.Models.Request;
using WMarket.Modules.UseCases.Product.Update.Models.Response;

namespace WMarket.Modules.UseCases.Product.Update.Interfaces;

public interface IUpdateProductModule: IModule<UpdateProductModuleRequest, UpdateProductModuleResponse>;