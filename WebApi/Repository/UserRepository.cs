using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;
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

    public ICollection<User> GetUsers()
    {
        return _context.Users.OrderBy(u => u.Name).ToList();
    }
    public User? GetUser(string name)
    {
        return _context.Users.Where(u => u.Name == name).FirstOrDefault();
    }

    public bool ValidateUser(string name, string password)
    {
        var user = GetUser(name);
        if (user is not null)
        {
            string decryptedPass = _encryptionService.Decrypt(user.Password);
            if (password == decryptedPass) return true;
        }
        return false;

    }

    public bool UserExists(string name)
    {
        return _context.Users.Any(u => u.Name == name);
    }

    public User CreateUser(string name, string password, string avatar)
    {

        string encryptedPassword = _encryptionService.Encrypt(password);

        var user = new User()
        {
            UserId = new Guid(),
            Name = name,
            Password = encryptedPassword,
            Avatar = avatar,
            IsOnline = true,
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return user;
    }
}