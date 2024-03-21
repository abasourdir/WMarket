namespace WMarket.Data.Repositories.Product.Models.Request;

public class GetPagedProductsRepositoryRequest
{
    public int Limit { get; set; }

    public int Offset { get; set; }
}