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
            var createdMessageId = await _messagesService.CreateAsync(message);

            if (createdMessageId == 0 || createdMessageId == -1)
                return BadRequest(ApiResponse.Failure($"Message Creation Failed"));

            return Ok(ApiResult<int>.Success(createdMessageId, "Message sent successfully"));
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
