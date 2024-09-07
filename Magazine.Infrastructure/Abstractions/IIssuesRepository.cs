using Magazine.Domain;
using Magazine.Domain.Entities;

namespace Magazine.Infrastructure.Abstractions;

public interface IIssuesRepository : IRepository<Issue>
{
    Task<IEnumerable<IssueShortInfo>> GetAllShortAsync();
    Task<Issue?> LatestAsync();
}

