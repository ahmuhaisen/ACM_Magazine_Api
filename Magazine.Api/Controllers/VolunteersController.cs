using Magazine.Api.Shared;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.Api.Controllers;

[Route("api/[controller]")]
public class VolunteersController(IVolunteersService _volunteersService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var data = await _volunteersService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<VolunteerDTO>>.Success(data));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{volunteerId:int}")]
    public async Task<IActionResult> GetValue(int volunteerId)
    {
        try
        {
            var data = await _volunteersService.GetByIdAsync(volunteerId);

            if (data is not null)
                return Ok(ApiResult<VolunteerDTO>.Success(data));
            else
                return Ok(ApiResponse.Failure($"Volunteer with Id {volunteerId} not found."));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{volunteerId:int}/contributions")]
    public async Task<IActionResult> GetVolunteerContributions(int volunteerId)
    {
        try
        {
            var data = await _volunteersService.GetVolunteerWithContributionsByIdAsync(volunteerId);
            if (data is not null)
                return Ok(ApiResult<VolunteerWithContributionsDTO>.Success(data));
            else
                return Ok(ApiResponse.Failure($"Volunteer with Id {volunteerId} not found."));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }
}
