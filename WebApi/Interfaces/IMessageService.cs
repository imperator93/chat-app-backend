using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Interfaces;

public interface IMessageService
{
    Task<IEnumerable<MessageResponseDto>> GetAllMessagesAsync();
    Task<MessageResponseDto> CreateMessageAsync(MessageRequestDto messageRequestDto);
    Task<bool> DeleteMessageAsync(MessageRequestDto messageRequestDto);
}