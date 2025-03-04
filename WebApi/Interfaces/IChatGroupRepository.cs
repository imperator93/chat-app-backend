using WebApi.Models;

namespace WebApi.Interfaces;

public interface IChatGroupRepository
{
    Task<ChatGroup> GetChatGroup(Guid Id);
}