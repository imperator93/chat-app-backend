using WebApi.Dto;
using WebApi.Interfaces;
using AutoMapper;

namespace WebApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<UserResponseDto>> GetAllAsync()
    {
        return _mapper.Map<List<UserResponseDto>>(await _userRepository.GetUsers());
    }
    public async Task<UserResponseDto> ValidateAndReturnUserAsync(UserRequestDto userRequestDto)
    {
        return _mapper.Map<UserResponseDto>(await _userRepository.ValidateAndReturnUser(userRequestDto));
    }

    public async Task<UserResponseDto> CreateUserAsync(UserRequestDto userRequestDto)
    {
        return _mapper.Map<UserResponseDto>(await _userRepository.CreateUser(userRequestDto));
    }
}