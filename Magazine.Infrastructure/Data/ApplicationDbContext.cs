using Magazine.Domain.Entities;
using Magazine.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Magazine.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options){}


    public DbSet<Issue> Issues { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IssuesConfig).Assembly);
    }
}
