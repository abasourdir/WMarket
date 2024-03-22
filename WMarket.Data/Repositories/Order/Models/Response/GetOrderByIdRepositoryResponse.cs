using WMarket.Common.Models.Enum.Order;

namespace WMarket.Data.Repositories.Order.Models.Response;

public class GetOrderByIdRepositoryResponse
{
    public long Id { get; set; }

    public DateTime DeliveryDate { get; set; }

    public OrderStatus Status { get; set; }
}