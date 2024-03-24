namespace WMarket.Data.ConnectionDecorators;

public interface IConnectionDecorator
{
    Task<IEnumerable<TResponse>> QueryAsync<TResponse>(string procedureName, object? request = null);
    
    Task<TResponse?> QueryFirstOrDefaultAsync<TResponse>(string procedureName, object? request = null);

    Task ExecuteAsync(string procedureName, object? request = null);

    Task<TResponse?> ExecuteScalarAsync<TResponse>(string procedureName, object? request = null);
}