using Magazine.Api.Shared;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Magazine.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.Api.Controllers;

[Route("api/[controller]")]
public class IssuesController(IIssuesService _issuesService, ILogger<IssuesController> _logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = new ApiResponse<IEnumerable<IssueDTO>>();

        try
        {
            var data = await _issuesService.GetAllAsync();
            response.Success = true;
            response.Data = data;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Occurs in IssuesController.GetAllAsync {1}", ex.Message);
            response.Success = false;
            response.Message = $"Something went wrong, {ex.Message}";
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{issueId:int}")]
    public async Task<IActionResult> GetValue(int issueId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{issueId:int}/team")]
    public async Task<IActionResult> GetIssueTeam(int issueId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{issueId:int}/team/{roleId:int}")]
    public async Task<IActionResult> GetIssueTeamWithRole(int issueId, int roleId)
    {
        throw new NotImplementedException();
    }
}
