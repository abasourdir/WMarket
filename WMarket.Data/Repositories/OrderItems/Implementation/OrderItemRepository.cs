using WMarket.Data.ConnectionDecorators.Sql.Interfaces;
using WMarket.Data.Repositories.OrderItems.Interfaces;
using WMarket.Data.Repositories.OrderItems.Models.Request;

namespace WMarket.Data.Repositories.OrderItems.Implementation;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly ISqlConnectionDecorator _connectionDecorator;

    public OrderItemRepository(ISqlConnectionDecorator connectionDecorator)
    {
        _connectionDecorator = connectionDecorator;
    }
    
    public Task InsertAsync(InsertOrderItemRepositoryRequest request)
        => _connectionDecorator.ExecuteAsync("[dbo].[OrderItems_Insert]", request);
}