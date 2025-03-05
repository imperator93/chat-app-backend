using WebApi.Models;

namespace WebApi.Interfaces;

public interface IChatGroupRepository
{
    Task<ChatGroup> CreateChatGroup(List<User> users);
    Task<ChatGroup> GetChatGroup(Guid Id, Guid UserId);
}