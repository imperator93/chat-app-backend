using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
    public IActionResult GetUsers()
    {
        var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

        if (!ModelState.IsValid) BadRequest(ModelState);

        return Ok(users);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(UserDto))]
    public IActionResult CreateUser(string name, string password, string avatar)
    {
        var user = _userRepository.CreateUser(name, password, avatar);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        // FIX THIS (only here because removing last migration)
        return null;

    }
}