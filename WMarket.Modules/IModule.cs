namespace WMarket.Modules;

public interface IModule<in TRequest, TResponse>
{
    Task<TResponse> ExecuteAsync(TRequest request);
}