using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;

namespace Magazine.Infrastructure.Repositories;
public class IssuesRepository : Repository<Issue>, IIssuesRepository
{
    public IssuesRepository(ApplicationDbContext _db) : base(_db)
    {
    }
}
