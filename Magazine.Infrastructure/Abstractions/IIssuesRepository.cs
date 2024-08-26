using Magazine.Domain.Entities;
using Magazine.Infrastructure.Repositories;

namespace Magazine.Infrastructure.Abstractions;
public interface IIssuesRepository :  IRepository<Issue>
{
}
