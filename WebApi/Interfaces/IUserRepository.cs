using WebApi.Models;

namespace WebApi.Interfaces;

public interface IUserRepository
{
    ICollection<User> GetUsers();
    User? GetUser(string name);
    User CreateUser(User user);
    bool UserExists(string name);
    bool ValidateUser(string name, string password, string avatar);
}
