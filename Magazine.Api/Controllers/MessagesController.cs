using Magazine.Api.Shared;
using Magazine.Application.Abstractions;
using Magazine.Application.DTOs;
using Magazine.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController(IMessagesService _messagesService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MessageDTO message)
    {
        try
        {
            await Task.Delay(3000);
            var affectedRows = await _messagesService.CreateAsync(message);

            if (affectedRows == 0 || affectedRows == -1)
                return BadRequest(ApiResponse.Failure($"Message Creation Failed"));

            return Ok(ApiResult<int>.Success(affectedRows, "Message sent successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _messagesService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<MessageDTO>>.Success(data));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }
}
