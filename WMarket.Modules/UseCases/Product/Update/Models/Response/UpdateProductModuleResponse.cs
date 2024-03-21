namespace WMarket.Modules.UseCases.Product.Update.Models.Response;

public class UpdateProductModuleResponse
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
}