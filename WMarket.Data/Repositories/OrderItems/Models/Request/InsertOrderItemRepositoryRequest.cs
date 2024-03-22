namespace WMarket.Data.Repositories.OrderItems.Models.Request;

public class InsertOrderItemRepositoryRequest
{
    public long ProductId { get; set; }

    public long OrderId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}