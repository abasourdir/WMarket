using WMarket.Common.Models.Enum;
using WMarket.Common.Models.Enum.Order;
using WMarket.Common.Models.Exceptions;
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
        var productIds = request.Products.Select(s => s.Id).Distinct().ToList();

        var products = (await _productRepository.GetByIdsAsync(new()
        {
            Ids = productIds
        })).ToList();

        var insufficientProducts = products.Where(w => !productIds.Contains(w.Id)).Select(s => s.Id).ToList();

        if (insufficientProducts.Count != 0)
            throw new BusinessException(ErrorCode.ProductNotFound,
                $"Products [{string.Join(", ", insufficientProducts)}] were not found for order");
        
        var deliveryDate = DateTime.Now.Date.AddDays(Random.Shared.Next(1, 10));

        var orderId = await _orderRepository.InsertAsync(new()
        {
            DeliveryDate = deliveryDate,
            Status = OrderStatus.New
        });

        foreach (var orderProduct in request.Products)
        {
            var product = products.First(f => f.Id == orderProduct.Id);

            await _orderItemRepository.InsertAsync(new()
            {
                ProductId = orderProduct.Id,
                OrderId = orderId,
                Quantity = orderProduct.Quantity,
                Price = product.Price
            });
        }

        return new CreateOrderModuleResponse
        {
            Id = orderId,
            DeliveryDate = deliveryDate
        };
    }
}