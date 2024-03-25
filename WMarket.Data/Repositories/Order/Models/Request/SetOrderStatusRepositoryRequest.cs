using WMarket.Common.Models.Enum.Order;

namespace WMarket.Data.Repositories.Order.Models.Request;

public class SetOrderStatusRepositoryRequest
{
    public long Id { get; set; }

    public OrderStatus Status { get; set; }
}