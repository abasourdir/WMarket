using WMarket.Common.Models.Enum.Order;
using WMarket.Data.Repositories.Order.Interfaces;
using WMarket.Data.Repositories.OrderItems.Interfaces;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Modules.UseCases.Order.Create.Interfaces;
using WMarket.Modules.UseCases.Order.Create.Models.Request;
using WMarket.Modules.UseCases.Order.Create.Models.Response;

namespace WMarket.Modules.UseCases.Order.Create.Implementation;

public class CreateOrderModule : ICreateOrderModule
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;

    public CreateOrderModule(
        IProductRepository productRepository,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
    }

    public async Task<CreateOrderModuleResponse> ExecuteAsync(CreateOrderModuleRequest request)
    {
        var deliveryDate = DateTime.Now.Date.AddDays(Random.Shared.Next(1, 10));

        var orderId = await _orderRepository.InsertAsync(new()
        {
            DeliveryDate = deliveryDate,
            Status = OrderStatus.New
        });

        foreach (var orderProduct in request.Products)
        {
            var product = await _productRepository.GetByIdAsync(new()
            {
                Id = orderProduct.Id
            });

            await _orderItemRepository.InsertAsync(new()
            {
                ProductId = orderProduct.Id,
                OrderId = orderId,
                Quantity = orderProduct.Quantity,
                Price = product!.Price
            });
        }

        return new CreateOrderModuleResponse
        {
            Id = orderId,
            DeliveryDate = deliveryDate
        };
    }
}