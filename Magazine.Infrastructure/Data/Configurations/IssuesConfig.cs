using Magazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magazine.Infrastructure.Data.Configurations;

public class IssuesConfig : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.Property(i => i.Title)
            .HasMaxLength(50);

        builder.Property(i => i.Description)
            .HasMaxLength(100);

        builder.HasData(SeedIssues());
    }

    private Issue[] SeedIssues()
    {
        return new Issue[]
        {
            new() {
                Id = 1,
                Number = 16,
                Title= "Cyber Security",
                Description="2024 issue highlights cybersecurity trends, challenges, and expert insights",
                PublishedAt = new DateTime(2024, 4, 6),
                Year = 2024,
                CoverImageUrl = "issues-covers/16.png"
            },
        };
    }
}
