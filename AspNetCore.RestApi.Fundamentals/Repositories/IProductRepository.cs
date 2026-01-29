using AspNetCore.RestApi.Fundamentals.Models;

namespace AspNetCore.RestApi.Fundamentals.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    Product Create(Product product);
    bool Update(Product product);
    bool Delete(int id);
    bool ExistsByName(string name, int? excludingId = null);
}