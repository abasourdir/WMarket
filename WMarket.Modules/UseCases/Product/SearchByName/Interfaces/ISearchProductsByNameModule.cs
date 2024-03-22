using WMarket.Modules.UseCases.Product.SearchByName.Models.Request;
using WMarket.Modules.UseCases.Product.SearchByName.Models.Response;

namespace WMarket.Modules.UseCases.Product.SearchByName.Interfaces;

public interface ISearchProductsByNameModule : IModule<SearchProductsByNameModuleRequest, SearchProductsByNameModuleResponse>;