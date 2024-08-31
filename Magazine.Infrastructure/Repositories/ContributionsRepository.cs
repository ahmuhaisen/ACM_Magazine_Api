using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Magazine.Infrastructure.Repositories;

public class ContributionsRepository : Repository<Contribution>, IContributionsRepository
{
    private readonly ApplicationDbContext _db;

    public ContributionsRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Contribution>> GetContributionsByIssueId(int issueId)
    {
        return await _db.Contributions
            .AsNoTracking()
            .Where(c => c.IssueId == issueId)
            .Include(c => c.Volunteer)
            .Include(c => c.Role)
            .ToListAsync();
    }
}
