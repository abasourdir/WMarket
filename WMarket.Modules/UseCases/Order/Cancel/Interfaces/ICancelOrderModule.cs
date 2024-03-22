using WMarket.Modules.UseCases.Order.Cancel.Models.Request;
using WMarket.Modules.UseCases.Order.Cancel.Models.Response;

namespace WMarket.Modules.UseCases.Order.Cancel.Interfaces;

public interface ICancelOrderModule : IModule<CancelOrderModuleRequest, CancelOrderModuleResponse>;