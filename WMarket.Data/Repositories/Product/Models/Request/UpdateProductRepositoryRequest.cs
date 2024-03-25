﻿namespace WMarket.Data.Repositories.Product.Models.Request;

public class UpdateProductRepositoryRequest
{
    public long Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal? Price { get; set; }
}