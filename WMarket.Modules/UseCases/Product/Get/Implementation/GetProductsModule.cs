using MapsterMapper;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Modules.UseCases.Product.Get.Interfaces;
using WMarket.Modules.UseCases.Product.Get.Models.Request;
using WMarket.Modules.UseCases.Product.Get.Models.Response;

namespace WMarket.Modules.UseCases.Product.Get.Implementation;

public class GetProductsModule : IGetProductsModule
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductsModule(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    
    public async Task<GetProductsModuleResponse> ExecuteAsync(GetProductsModuleRequest request)
    {
        var result = await _productRepository.GetPagedAsync(new()
        {
            Limit = request.Limit,
            Offset = request.CurrentPage > 1
                ? request.Limit * (request.CurrentPage.Value - 1)
                : 0
        });

        return new GetProductsModuleResponse
        {
            Data = _mapper.From(result).AdaptToType<List<GetProductsModuleResponseData>>()
        };
    }
}