using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;
using WebApi.Dto;

namespace WebApi.Repository;
//nonexistent error handling... will implement in future
public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly EncryptionService _encryptionService;
    public UserRepository(DataContext context, EncryptionService encryptionService)
    {
        _context = context;
        _encryptionService = encryptionService;
    }

    public async Task<ICollection<User>> GetUsers()
    {
        return await _context.Users.OrderBy(u => u.Name).ToListAsync();
    }
    public async Task<User?> GetUser(string name)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
    }

    public async Task<User?> ValidateAndReturnUser(UserRequestDto userRequestDto)
    {
        var user = await GetUser(userRequestDto.Name);

        if (user is not null)
        {
            if (user.Password is not null)
            {
                string decryptedPass = _encryptionService.Decrypt(user.Password);

                if (userRequestDto.Password == decryptedPass) return user;

                return null;
            }
        }

        return null;
    }

    public async Task<bool> UserExists(string name)
    {
        return await _context.Users.AnyAsync(u => u.Name == name);
    }

    public async Task<User?> CreateUser(UserRequestDto userRequestDto)
    {
        if (await UserExists(userRequestDto.Name)) return null;

        string encryptedPassword = _encryptionService.Encrypt(userRequestDto.Password);

        var user = new User()
        {
            Id = new Guid(),
            Name = userRequestDto.Name,
            Password = encryptedPassword,
            Avatar = userRequestDto.Avatar,
            IsOnline = true,
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
}