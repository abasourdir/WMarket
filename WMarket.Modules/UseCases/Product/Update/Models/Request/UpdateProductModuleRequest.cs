namespace WMarket.Modules.UseCases.Product.Update.Models.Request;

public class UpdateProductModuleRequest
{
    public long Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal? Price { get; set; }
}