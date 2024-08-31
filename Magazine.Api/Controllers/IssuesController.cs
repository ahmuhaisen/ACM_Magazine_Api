using Microsoft.AspNetCore.Mvc;
using Magazine.Api.Shared;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;

namespace Magazine.Api.Controllers;

[Route("api/[controller]")]
public class IssuesController(IIssuesService _issuesService, ILogger<IssuesController> _logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var data = await _issuesService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<IssueDTO>>.Success(data));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{issueId:int}")]
    public async Task<IActionResult> GetValue(int issueId)
    {
        try
        {
            var data = await _issuesService.GetByIdAsync(issueId);

            if (data is not null)
                return Ok(ApiResult<IssueDTO>.Success(data));
            else
                return Ok(ApiResponse.Failure($"Issue with Id {issueId} not found."));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{issueId:int}/team")]
    public async Task<IActionResult> GetIssueTeam(int issueId)
    {
        try
        {
            var data = await _issuesService.GetIssueTeam(issueId);
            return Ok(ApiResult<IEnumerable<IssueContributorDTO>>.Success(data));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{issueId:int}/team/{roleId:int}")]
    public async Task<IActionResult> GetIssueTeamWithRole(int issueId, int roleId)
    {
        throw new NotImplementedException();
    }
}
