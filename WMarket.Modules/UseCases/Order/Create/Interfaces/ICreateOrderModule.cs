using WMarket.Modules.UseCases.Order.Create.Models.Request;
using WMarket.Modules.UseCases.Order.Create.Models.Response;

namespace WMarket.Modules.UseCases.Order.Create.Interfaces;

public interface ICreateOrderModule : IModule<CreateOrderModuleRequest, CreateOrderModuleResponse>;