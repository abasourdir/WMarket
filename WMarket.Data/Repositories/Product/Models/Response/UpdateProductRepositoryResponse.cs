namespace WMarket.Data.Repositories.Product.Models.Response;

public class UpdateProductRepositoryResponse
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
}