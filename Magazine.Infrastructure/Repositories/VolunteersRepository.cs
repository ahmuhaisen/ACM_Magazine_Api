using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;

namespace Magazine.Infrastructure.Repositories;

public class VolunteersRepository : Repository<Volunteer>, IVolunteersRepository
{
    public VolunteersRepository(ApplicationDbContext db) : base(db)
    {
    }
}
