namespace Magazine.Domain.Entities;

public class Contribution : IEntity
{
    public int Id { get; set; }

    public int VolunteerId { get; set; }
    public required Volunteer Volunteer { get; set; }

    public int RoleId { get; set; }
    public required Role Role { get; set; }

    public int IssueId { get; set; }
    public required Issue Issue { get; set; }
}