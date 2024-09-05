using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;


namespace Magazine.Infrastructure.Repositories;

public class MessagesRepository : Repository<Message>, IMessagesRepository
{
    private readonly ApplicationDbContext _db;

    public MessagesRepository(ApplicationDbContext db) : base(db) => _db = db;

}
