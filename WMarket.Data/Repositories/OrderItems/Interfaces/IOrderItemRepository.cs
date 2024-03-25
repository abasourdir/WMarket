using WMarket.Data.Repositories.OrderItems.Models.Request;

namespace WMarket.Data.Repositories.OrderItems.Interfaces;

public interface IOrderItemRepository : IRepository
{
    Task InsertAsync(InsertOrderItemRepositoryRequest request);
}