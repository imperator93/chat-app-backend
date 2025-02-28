using WebApi.Models;

namespace WebApi.Interfaces;

public interface IUserRepository
{
    ICollection<User> GetUsers();
    User GetUser(Guid id);
    User GetUser(string name);
}
