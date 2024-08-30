using Microsoft.AspNetCore.Mvc;

namespace Magazine.Api.Controllers;

[Route("api/[controller]")]
public class VolunteersController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{volunteerId:int}")]
    public async Task<IActionResult> GetValue(int volunteerId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{volunteerId:int}/contributions")]
    public async Task<IActionResult> GetVolunteerContributions(int volunteerId)
    {
        throw new NotImplementedException();
    }
}
