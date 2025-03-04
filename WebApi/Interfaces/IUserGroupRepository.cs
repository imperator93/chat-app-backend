using WebApi.Models;

namespace WebApi.Interfaces;

public interface IUserGroupRepository
{
    Task<bool> CreateUserGroup(ICollection<Guid> userIds);
    Task<UserGroup> GetUserGroup(Guid Id);
}