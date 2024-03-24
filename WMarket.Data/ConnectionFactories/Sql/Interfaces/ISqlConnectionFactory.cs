using Microsoft.Data.SqlClient;

namespace WMarket.Data.ConnectionFactories.Sql.Interfaces;

public interface ISqlConnectionFactory : IConnectionFactory<SqlConnection>;