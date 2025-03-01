using WebApi.Models;

namespace WebApi.Interfaces;

public interface IMessageRepository
{
    ICollection<Message> GetMessages();
}