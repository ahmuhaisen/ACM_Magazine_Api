using Magazine.Domain;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Magazine.Infrastructure.Repositories;

public class Repository<T>(ApplicationDbContext _db) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _db.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _db.Set<T>().FindAsync(id);
    }

    public async Task<PaginatedList<T>> GetPageAsync<TKey>(int pageIndex,
                                                           int pageSize,
                                                           Expression<Func<T, TKey>> orderByTerm)
    {
        var data = await _db.Set<T>()
            .OrderByDescending(orderByTerm)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await _db.Set<T>().CountAsync();
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return new PaginatedList<T>(data, pageIndex, totalPages);
    }
}
