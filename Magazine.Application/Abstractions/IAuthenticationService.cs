using Magazine.Application.DTOs.Authentication;

namespace Magazine.Application.Abstractions;


public interface IAuthenticationService
{
    Task<AuthenticationResponse> RegisterAsync(RegisterRequest request);
}
