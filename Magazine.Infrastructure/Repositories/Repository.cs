using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
}
