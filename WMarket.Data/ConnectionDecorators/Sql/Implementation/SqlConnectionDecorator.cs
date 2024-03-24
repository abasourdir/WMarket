using System.Data;
using Dapper;
using WMarket.Data.ConnectionDecorators.Sql.Interfaces;
using WMarket.Data.ConnectionFactories.Sql.Interfaces;
using WMarket.Data.Poly;

namespace WMarket.Data.ConnectionDecorators.Sql.Implementation;

public class SqlConnectionDecorator : ISqlConnectionDecorator
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SqlConnectionDecorator(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    
    public async Task<IEnumerable<TResponse>> QueryAsync<TResponse>(string procedureName, object? request = null)
    {
        var result = await DatabaseRetryPolicy.Value.ExecuteAndCaptureAsync(async () =>
        {
            var connection = await _sqlConnectionFactory.OpenAsync();

            var result =
                await connection.QueryAsync<TResponse>(procedureName, request,
                    commandType: CommandType.StoredProcedure);

            return result;
        });

        return result.Result;
    }

    public async Task<TResponse?> QueryFirstOrDefaultAsync<TResponse>(string procedureName, object? request = null)
    {
        var result = await DatabaseRetryPolicy.Value.ExecuteAndCaptureAsync(async () =>
        {
            var connection = await _sqlConnectionFactory.OpenAsync();

            var result =
                await connection.QueryFirstOrDefaultAsync<TResponse>(procedureName, request,
                    commandType: CommandType.StoredProcedure);

            return result;
        });

        return result.Result;
    }

    public async Task ExecuteAsync(string procedureName, object? request = null)
    {
        await DatabaseRetryPolicy.Value.ExecuteAndCaptureAsync(async () =>
        {
            var connection = await _sqlConnectionFactory.OpenAsync();

            var result =
                await connection.ExecuteAsync(procedureName, request,
                    commandType: CommandType.StoredProcedure);

            return result;
        });
    }

    public async Task<TResponse?> ExecuteScalarAsync<TResponse>(string procedureName, object? request = null)
    {
        var result = await DatabaseRetryPolicy.Value.ExecuteAndCaptureAsync(async () =>
        {
            var connection = await _sqlConnectionFactory.OpenAsync();

            var result =
                await connection.ExecuteScalarAsync<TResponse>(procedureName, request,
                    commandType: CommandType.StoredProcedure);

            return result;
        });

        return result.Result;
    }
}