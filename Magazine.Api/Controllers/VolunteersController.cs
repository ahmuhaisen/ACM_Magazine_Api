﻿using Magazine.Api.Common;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Magazine.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VolunteersController(IVolunteersService _volunteersService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 5)
    {
        try
        {
            var data = await _volunteersService.GetVolunteersPageAsync(pageIndex, pageSize);
            return Ok(ApiResult<PaginatedList<VolunteerDTO>>.Success(data));
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

    [HttpGet("top")]
    public async Task<IActionResult> GetTopContributors([FromQuery]int number = 3)
    {
        try
        {
            var data = await _volunteersService.GetTopContributorsAsync(number);
            return Ok(ApiResult<IEnumerable<VolunteerDTO>>.Success(data));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }
}
