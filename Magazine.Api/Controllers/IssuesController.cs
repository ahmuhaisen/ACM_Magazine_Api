using Magazine.Api.Shared;
using Magazine.Domain.Entities;
using Magazine.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.Api.Controllers;

[Route("api/[controller]")]
public class IssuesController(IIssuesRepository _repo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = new ApiResponse<IEnumerable<Issue>>();

        try
        {
            var data = await _repo.GetAllAsync();
            response.Success = true;
            response.Data = data;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"Something went wrong, {ex.Message}";
            return BadRequest(response);
        }

        return Ok(response);
    }
}
