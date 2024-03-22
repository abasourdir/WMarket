namespace WMarket.Modules.UseCases.Product.SearchByName.Models.Request;

public class SearchProductsByNameModuleRequest
{
    public string? Name { get; set; }
    
    public int? CurrentPage { get; set; }

    public int Limit { get; set; }
}