using Microsoft.Data.SqlClient;
using Polly;
using Polly.Retry;

namespace WMarket.Data.Poly;

public static class DatabaseRetryPolicy
{
    public static AsyncRetryPolicy Value { get; } =
        Policy.Handle<SqlException>()
            .Or<TimeoutException>()
            .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1));
}