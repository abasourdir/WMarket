using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using WMarket.Common.Models.IOptions;
using WMarket.Data.ConnectionFactories.Base;

namespace WMarket.Data.ConnectionFactories;

public class SqlConnectionFactory : IConnectionFactory<SqlConnection>
{
    private readonly ConnectionStrings _connectionStrings;

    public SqlConnectionFactory(IOptions<ConnectionStrings> connectionStrings)
    {
        _connectionStrings = connectionStrings.Value;
    }
    
    public async Task<SqlConnection> OpenAsync()
    {
        var connection = new SqlConnection(_connectionStrings.Default);
        await connection.OpenAsync();

        return connection;
    }
}