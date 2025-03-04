using WebApi.Interfaces;
using WebApi.Data;

namespace WebApi.Models;

public class UserGroupRepository : IUserGroupRepository
{
    private readonly DataContext _context;

    public UserGroupRepository(DataContext context)
    {
        _context = context;
    }

    //STUCK HERE (i think I need to create another table and not use junction table here)
    public async Task<bool> CreateUserGroup(ICollection<Guid> userIds)
    {

    }
}