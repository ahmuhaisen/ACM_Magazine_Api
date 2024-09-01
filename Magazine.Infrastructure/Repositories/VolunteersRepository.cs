﻿using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Magazine.Infrastructure.Repositories;

public class VolunteersRepository : Repository<Volunteer>, IVolunteersRepository
{
    private readonly ApplicationDbContext _db;

    public VolunteersRepository(ApplicationDbContext db) : base(db) => _db = db;
   

    public async Task<Volunteer?> GetWithContributionsAsync(int id)
    {
        return await _db.Volunteers
            .AsNoTracking()
            .Include(x => x.Contributions)
                .ThenInclude(c => c.Issue)
            .Include(x => x.Contributions)
                .ThenInclude(c => c.Role)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
