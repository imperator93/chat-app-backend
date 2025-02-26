using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<User> GetUsers()
    {
        return _context.Users.OrderBy(u => u.Name).ToList();
    }

    public User GetUser(Guid id)
    {
        return _context.Users.Where(u => u.UserId == id).FirstOrDefault();
    }

    public User GetUser(string name)
    {
        return _context.Users.Where(u => u.Name == name).FirstOrDefault();
    }
    public bool UserExists(Guid id)
    {
        return _context.Users.Any(u => u.UserId == id);
    }
}