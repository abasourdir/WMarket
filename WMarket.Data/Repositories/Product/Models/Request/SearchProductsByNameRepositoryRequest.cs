namespace WMarket.Data.Repositories.Product.Models.Request;

public class SearchProductsByNameRepositoryRequest
{
    public string? Name { get; set; }
    
    public int Limit { get; set; }

    public int Offset { get; set; }
}