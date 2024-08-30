namespace Magazine.Domain.Entities;

public class Issue : IEntity
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public int Year { get; set; }
    public int Number { get; set; }
    public DateTime PublishedAt { get; set; }
    public required string CoverImageUrl { get; set; }

    public ICollection<Contribution> Contributions { get; set; } = [];
}
