using Magazine.Domain;
using System.Linq.Expressions;

namespace Magazine.Infrastructure.Abstractions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    Task<PaginatedList<T>> GetPageAsync<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderByTerm);

    Task<int> CreateAsync(T item);
}
