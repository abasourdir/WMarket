using WMarket.Common.Models.Enum;
using WMarket.Common.Models.Enum.Order;
using WMarket.Common.Models.Exceptions;
using WMarket.Data.Repositories.Order.Interfaces;
using WMarket.Modules.UseCases.Order.Cancel.Interfaces;
using WMarket.Modules.UseCases.Order.Cancel.Models.Request;
using WMarket.Modules.UseCases.Order.Cancel.Models.Response;

namespace WMarket.Modules.UseCases.Order.Cancel.Implementation;

public class CancelOrderModule : ICancelOrderModule
{
    private readonly IOrderRepository _orderRepository;

    public CancelOrderModule(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<CancelOrderModuleResponse> ExecuteAsync(CancelOrderModuleRequest request)
    {
        var order = await _orderRepository.GetByIdAsync(new()
        {
            Id = request.Id
        });
        
        if (order is null)
            throw new BusinessException(ErrorCode.OrderNotFound, "Order was not found for cancellation");

        if (order.Status is OrderStatus.Cancelled)
            throw new BusinessException(ErrorCode.OrderAlreadyCancelled, "The order was already cancelled");
        
        await _orderRepository.SetStatusAsync(new()
        {
            Id = request.Id,
            Status = OrderStatus.Cancelled
        });

        return new CancelOrderModuleResponse
        {
            Id = request.Id
        };
    }
}