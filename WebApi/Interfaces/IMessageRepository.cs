using WebApi.Models;

namespace WebApi.Interfaces;

public interface IMessageRepository
{
    Task<ICollection<Message>> GetBroadcastMessages();
}