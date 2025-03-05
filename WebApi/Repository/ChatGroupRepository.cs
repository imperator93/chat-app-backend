using WebApi.Interfaces;
using WebApi.Data;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Repository;

public class ChatGroupRepository : IChatGroupRepository
{
    private readonly DataContext _context;

    public ChatGroupRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ChatGroup> CreateChatGroup(List<User> users)
    {
        var chatGroup = new ChatGroup()
        {
            Id = Guid.NewGuid(),
        };


    }

    public async Task<ChatGroup> GetChatGroup(Guid Id)
    {
        return await _context.ChatGroups.FirstOrDefaultAsync(cg => cg.Id == Id);
    }

}