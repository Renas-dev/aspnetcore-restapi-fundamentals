using AspNetCore.RestApi.Fundamentals.Models;

namespace AspNetCore.RestApi.Fundamentals.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products =
    [
        new Product { Id = 1, Name = "Keyboard", Price = 49.99m },
        new Product { Id = 2, Name = "Mouse", Price = 29.99m },
        new Product { Id = 3, Name = "Headphones", Price = 99.99m }        
    ];

    private int _nextId = 4;

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public Product Create(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }

    public bool Update(Product product)
    {
        var existing = GetById(product.Id);
        if (existing is null) return false;

        existing.Name = product.Name;
        existing.Price = product.Price;
        return true;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        if (existing is null) return false;

        _products.Remove(existing);
        _products.Remove(existing);
        return true;
    }

    public bool ExistsByName(string name, int? excludingId = null)
    {
        return _products.Any(p =>
        p.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
        (excludingId is null || p.Id != excludingId.Value));
    }
}