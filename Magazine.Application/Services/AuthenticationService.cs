using Magazine.Application.Abstractions;
using Magazine.Application.DTOs.Authentication;
using Magazine.Application.Options;
using Magazine.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Magazine.Application.Services;


public class AuthenticationService(
    UserManager<ApplicationUser> _userManager,
    IOptions<JwtOptions> _jwtOptions) : IAuthenticationService
{
    public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _userManager.FindByEmailAsync(request.Email) is not null)
            return new AuthenticationResponse { Message = "Email is already registered" };

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email.Substring(0, request.Email.IndexOf("@")),
            FullName = request.FullName,
            UniversityId = request.UniversityId,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Empty;
            errors = string.Join(',', result.Errors.Select(e => e.Description));
            return new AuthenticationResponse { Message = errors };
        }

        var jwtSecurityToken = await CreateJwtToken(user);

        return new AuthenticationResponse
        {
            Email = user.Email,
            ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
        };
    }



    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("uid", user.Id)
        }
        .Union(userClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.SigningKey!));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtOptions.Value.Issuer,
            audience: _jwtOptions.Value.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtOptions.Value.DurationInMinuets),
            signingCredentials: signingCredentials
        );
    }
}
