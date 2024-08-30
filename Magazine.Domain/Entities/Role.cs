namespace Magazine.Domain.Entities;

public class Role : IEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool isUnique { get; set; }
}
