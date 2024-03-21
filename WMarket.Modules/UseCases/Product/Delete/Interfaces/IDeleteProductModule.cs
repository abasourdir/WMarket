using WMarket.Modules.UseCases.Product.Delete.Models.Request;
using WMarket.Modules.UseCases.Product.Delete.Models.Response;

namespace WMarket.Modules.UseCases.Product.Delete.Interfaces;

public interface IDeleteProductModule : IModule<DeleteProductModuleRequest, DeleteProductModuleResponse>;