using WebApi.Interfaces;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public class UserGroupRepository : IUserGroupRepository
{
    private readonly DataContext _context;

    public UserGroupRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateUserGroup(ICollection<Guid> userIds)
    {
        var group = new UserGroup()
        {
            Id = Guid.NewGuid(),
        };

        var users = await _context.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();

        foreach (var user in users)
        {
            await _context.UserGroups.AddRangeAsync(new UserGroup()
            {
                Id = group.Id,
                UserId = user.Id,
            });
        }

        await _context.SaveChangesAsync();
    }
}