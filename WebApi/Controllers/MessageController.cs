using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Interfaces;

namespace WebApi.Controllers;

[Route("api")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet("/messages")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<MessageResponseDto>))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetMessages(MessageRequestDto messageRequestDto)
    {
        var messages = await _messageService.GetAllMessagesAsync();

        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (messages is null) return NotFound();

        return Ok(messages);
    }

    [HttpPost("/messages")]
    [ProducesResponseType(200, Type = typeof(MessageResponseDto))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> CreateMessage(MessageRequestDto messageRequestDto)
    {
        var message = await _messageService.CreateMessageAsync(messageRequestDto);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(message);
    }

    [HttpDelete("/messages")]
    [ProducesResponseType(200, Type = typeof(bool))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteMessage(MessageRequestDto messageRequestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(await _messageService.DeleteMessageAsync(messageRequestDto));
    }
}