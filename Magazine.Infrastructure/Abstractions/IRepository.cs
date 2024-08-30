using Magazine.Domain.Entities;

namespace Magazine.Infrastructure.Abstractions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);
}
