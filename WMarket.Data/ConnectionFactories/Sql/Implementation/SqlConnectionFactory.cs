using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using WMarket.Common.Models.IOptions;
using WMarket.Data.ConnectionFactories.Sql.Interfaces;

namespace WMarket.Data.ConnectionFactories.Sql.Implementation;

public class SqlConnectionFactory : ISqlConnectionFactory
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