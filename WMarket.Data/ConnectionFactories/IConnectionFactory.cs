using System.Data;

namespace WMarket.Data.ConnectionFactories;

public interface IConnectionFactory<T>
    where T : IDbConnection
{
    Task<T> OpenAsync();
}