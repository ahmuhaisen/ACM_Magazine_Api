using Microsoft.AspNetCore.Mvc;
using Magazine.Api.Shared;
using Magazine.Application.DTOs;
using Magazine.Application.Abstractions;

namespace Magazine.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController(IArticlesService _articlesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(int issueId)
    {
        try
        {
            var data = await _articlesService.GetArticlesByIssueId(issueId);
            return Ok(ApiResult<IEnumerable<ArticleDTO>>.Success(data));

        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }
}
