using System.Data;

namespace WMarket.Data.ConnectionFactories.Base;

public interface IConnectionFactory<T>
    where T : IDbConnection
{
    Task<T> OpenAsync();
}