using Magazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magazine.Infrastructure.Data.Configurations;


public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnType("tinyint");

        builder.Property(x => x.Name)
            .HasMaxLength(30);

        builder.Property(x => x.Description)
            .HasMaxLength(100);

        builder.Property(x => x.isUnique)
            .HasDefaultValue(false);
    }
}
