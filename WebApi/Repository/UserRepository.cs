using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Repository;

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

    public async Task<bool> ValidateUser(string name, string password)
    {
        var user = await GetUser(name);
        if (user is not null)
        {
            string decryptedPass = _encryptionService.Decrypt(user.Password);
            if (password == decryptedPass) return true;
        }
        return false;

    }

    public async Task<bool> UserExists(string name)
    {
        return await _context.Users.AnyAsync(u => u.Name == name);
    }

    public async Task<User> CreateUser(string name, string password, string avatar)
    {
        if (await UserExists(name)) return null;

        string encryptedPassword = _encryptionService.Encrypt(password);

        var user = new User()
        {
            Id = new Guid(),
            Name = name,
            Password = encryptedPassword,
            Avatar = avatar,
            IsOnline = true,
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
}