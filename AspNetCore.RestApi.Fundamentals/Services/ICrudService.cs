using AspNetCore.RestApi.Fundamentals.Abstractions;

namespace AspNetCore.RestApi.Fundamentals.Services;

public interface ICrudService<T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    (bool Success, string? Error, T? Entity) Create(T entity);
    (bool Success, string? Error, T? Entity) Update(int id, T entity);
    bool Delete(int id);

}
