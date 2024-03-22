using System.Data;
using Dapper;
using WMarket.Data.ConnectionFactories;
using WMarket.Data.Repositories.OrderItems.Interfaces;
using WMarket.Data.Repositories.OrderItems.Models.Request;

namespace WMarket.Data.Repositories.OrderItems.Implementation;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public OrderItemRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public async Task InsertAsync(InsertOrderItemRepositoryRequest request)
    {
        var connection = await _connectionFactory.OpenAsync();

        await connection.ExecuteAsync("[dbo].[OrderItems_Insert]", request, commandType: CommandType.StoredProcedure);
    }
}