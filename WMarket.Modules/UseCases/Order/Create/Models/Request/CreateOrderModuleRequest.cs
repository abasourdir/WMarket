namespace WMarket.Modules.UseCases.Order.Create.Models.Request;

public class CreateOrderModuleRequest
{
    public List<CreateOrderProductModuleRequest> Products { get; set; }
}

public class CreateOrderProductModuleRequest
{
    public long Id { get; set; }
    
    public int Quantity { get; set; }
}