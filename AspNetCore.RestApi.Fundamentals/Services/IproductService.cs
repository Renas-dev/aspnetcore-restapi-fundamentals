using AspNetCore.RestApi.Fundamentals.Models;

namespace AspNetCore.RestApi.Fundamentals.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);

    (bool Success, string? Error, Product? Product) Create(Product input);
    (bool Success, string? Error, Product? Product) Update(int id, Product input);

    bool Delete(int id);
}