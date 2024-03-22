using WMarket.Modules.Base.Models.Response;

namespace WMarket.Modules.UseCases.Product.SearchByName.Models.Response;

public class SearchProductsByNameModuleResponse : ModuleGenericResponse<List<SearchProductsByNameModuleResponseData>>;

public class SearchProductsByNameModuleResponseData
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}