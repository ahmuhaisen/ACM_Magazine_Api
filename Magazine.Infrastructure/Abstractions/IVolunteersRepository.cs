using Magazine.Domain.Entities;

namespace Magazine.Infrastructure.Abstractions;

public interface IVolunteersRepository : IRepository<Volunteer>
{
    Task<Volunteer?> GetWithContributionsAsync(int id);
    Task<IEnumerable<Volunteer>> GetTopContributorsAsync(int number);
}
