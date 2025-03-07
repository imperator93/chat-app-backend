using WebApi.Models;
using WebApi.Dto;

namespace WebApi.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetUsers();
    Task<User?> GetUser(string name);
    Task<User?> CreateUser(UserRequestDto userRequestDto);
    Task<User?> ValidateAndReturnUser(UserRequestDto userRequestDto);
    Task<bool> UserExists(string name);
}
