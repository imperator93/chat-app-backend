using WebApi.Models;

namespace WebApi.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetUsers();
    Task<User?> GetUser(string name);
    Task<User> CreateUser(string name, string password, string avatar);
    Task<bool> ValidateUser(string name, string password);
    Task<bool> UserExists(string name);
}
