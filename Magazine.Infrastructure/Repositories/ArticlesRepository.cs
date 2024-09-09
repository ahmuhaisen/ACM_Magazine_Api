using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;

namespace Magazine.Infrastructure.Repositories;


public class ArticlesRepository : Repository<Article>, IArticlesRepository
{
    public ArticlesRepository(ApplicationDbContext db) : base(db)
    {
    }
}
