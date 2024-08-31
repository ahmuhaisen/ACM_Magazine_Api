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

        builder.HasData(Seed());
    }

    private Role[] Seed()
    {
        return new[] {
            new Role { Id = 1, Name = "Director", Description = "Oversees the entire publication process and team.", isUnique = true },
            new Role { Id = 2, Name = "EditorInChief", Description = "Responsible for the overall editorial direction and content quality.", isUnique = true },
            new Role { Id = 3, Name = "Designer", Description = "Creates the visual design and layout for the publication.", isUnique = false },
            new Role { Id = 4, Name = "EditorialAssistant", Description = "Assists with editing and content management.", isUnique = false },
            new Role { Id = 5, Name = "ContributingWriter", Description = "Writes articles or content on a regular basis.", isUnique = false },
            new Role { Id = 6, Name = "GuestWriter", Description = "Contributes content occasionally, usually for special topics.", isUnique = false },
            new Role { Id = 7, Name = "VoiceOver", Description = "Provides narration or voiceovers for the podcast version.", isUnique = false }
        };
    }
}
