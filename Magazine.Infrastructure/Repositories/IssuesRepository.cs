using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Magazine.Infrastructure.Repositories;
public class IssuesRepository : Repository<Issue>, IIssuesRepository
{
    private readonly ApplicationDbContext _db;

    public IssuesRepository(ApplicationDbContext db) : base(db) => _db = db;

    public async Task<Issue?> LatestAsync()
    {
        return await _db.Issues
            .AsNoTracking()
            .OrderByDescending(x => x.PublishedAt)
            .FirstOrDefaultAsync();
    }
}
