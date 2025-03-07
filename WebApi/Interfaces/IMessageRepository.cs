using WebApi.Models;
using WebApi.Dto;

namespace WebApi.Interfaces;

public interface IMessageRepository
{
    Task<ICollection<Message>> GetBroadcastMessages();
    Task<Message> CreateMessage(MessageRequestDto messageRequestDto);
}