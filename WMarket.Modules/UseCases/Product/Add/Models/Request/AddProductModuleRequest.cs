namespace WMarket.Modules.UseCases.Product.Add.Models.Request;

public class AddProductModuleRequest
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
}