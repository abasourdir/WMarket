namespace WMarket.Data.Repositories.Product.Models.Request;

public class ProductByIdsRepositoryRequest
{
    public required IEnumerable<long> Ids { get; set; }
}