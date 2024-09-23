using Magazine.Application.Abstractions;
using Magazine.Application.DTOs.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IAuthenticationService _authService) : ControllerBase
{
    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        try
        {
            var response = await _authService.RegisterAsync(request);

            if (!response.IsAuthenticated) 
                return BadRequest(response);

            return Ok(response);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> login([FromBody] LoginRequest request)
    {
        try
        {
            var response = await _authService.LoginAsync(request);

            if (!response.IsAuthenticated)
                return BadRequest(response);

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
