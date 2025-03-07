using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Interfaces;

public interface IUserService
{
    public Task<ICollection<UserResponseDto>> GetAllAsync();
    public Task<UserResponseDto> ValidateAndReturnUserAsync(UserRequestDto userRequestDto);
    public Task<UserResponseDto> CreateUserAsync(UserRequestDto userRequestDto);
}