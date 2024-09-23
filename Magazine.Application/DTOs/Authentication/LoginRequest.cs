using System.ComponentModel.DataAnnotations;

namespace Magazine.Application.DTOs.Authentication;


public class LoginRequest
{
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [MinLength(6)]
    public required string Password { get; set; }
}
