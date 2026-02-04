using AspNetCore.RestApi.Fundamentals.Abstractions;

namespace AspNetCore.RestApi.Fundamentals.Models;

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }   
}