using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet("/users")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<UserResponseDto>))]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllAsync();

        if (!ModelState.IsValid) BadRequest(ModelState);

        return Ok(users);
    }

    [HttpPost("/user")]
    [ProducesResponseType(200, Type = typeof(UserResponseDto))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetUser(UserRequestDto userRequestDto)
    {
        var user = await _userService.ValidateAndReturnUserAsync(userRequestDto);

        if (!ModelState.IsValid) BadRequest(ModelState);

        return Ok(user);
    }

    [HttpPost("/users")]
    [ProducesResponseType(200, Type = typeof(UserResponseDto))]
    public async Task<IActionResult> CreateUser(UserRequestDto userRequestDto)
    {
        var user = await _userService.CreateUserAsync(userRequestDto);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(user);
    }
}