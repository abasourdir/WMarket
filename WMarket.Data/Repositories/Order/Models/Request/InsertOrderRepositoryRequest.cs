using WMarket.Common.Models.Enum.Order;

namespace WMarket.Data.Repositories.Order.Models.Request;

public class InsertOrderRepositoryRequest
{
    public DateTime DeliveryDate { get; set; }

    public OrderStatus Status { get; set; }
}