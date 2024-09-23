

using Microsoft.AspNetCore.Identity;

namespace Magazine.Domain.Entities;


public class ApplicationUser : IdentityUser
{
    public required string FullName { get; set; }
    public required string UniversityId { get; set; }
}
