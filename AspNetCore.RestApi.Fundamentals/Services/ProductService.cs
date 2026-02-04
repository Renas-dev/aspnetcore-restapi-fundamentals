using AspNetCore.RestApi.Fundamentals.Abstractions;
using AspNetCore.RestApi.Fundamentals.Models;
using AspNetCore.RestApi.Fundamentals.Repositories;

namespace AspNetCore.RestApi.Fundamentals.Services;

public class ProductService : ICrudService<Product>
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Product> GetAll()
    {
        return _repo.GetAll();
    }

    public Product? GetById(int id)
    {
        return _repo.GetById(id);
    }

    public (bool Success, string? Error, Product? Entity) Create(Product entity)

    {
        var validationError = Validate(entity);
        if (validationError is not null)
        {
            return (false, validationError, null);
        }

        if (_repo.ExistsByName(entity.Name))
        {
            return (false, "Product name must be unique.", null);
        }

        var created = _repo.Create(new Product
        {
            Name = entity.Name.Trim(),
            Price = entity.Price
        });

        return (true, null, created);
    }

    public (bool Success, string? Error, Product? Entity) Update(int id, Product entity)

    {
        var existing = _repo.GetById(id);
        if (existing is null)
        {
            return (false, "Product not found.", null);
        }

        var validationError = Validate(entity);
        if (validationError is not null)
        {
            return (false, validationError, null);
        }

        if (_repo.ExistsByName(entity.Name, excludingId: id))
        {
            return (false, "Product name must be unique.", null);
        }

        existing.Name = entity.Name.Trim();
        existing.Price = entity.Price;

        var success = _repo.Update(existing);
        if (!success)
        {
            return (false, "Update failed.", null);
        }

        return (true, null, existing);
    }

    public bool Delete(int id)
    {
        return _repo.Delete(id);
    }

    private static string? Validate(Product input)
    {
        if (string.IsNullOrWhiteSpace(input.Name))
        {
            return "Name is required.";
        }

        if (input.Price < 0)
        {
            return "Price cannot be negative.";
        }

        return null;
    }
}
