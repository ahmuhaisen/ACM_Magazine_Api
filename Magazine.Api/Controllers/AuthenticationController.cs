using Azure;
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

            if (response is null || !response.IsAuthenticated) 
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
    public async Task<IActionResult> login()
    {
        throw new NotImplementedException();
    }
}
