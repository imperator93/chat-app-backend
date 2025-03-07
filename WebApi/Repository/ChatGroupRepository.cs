using WebApi.Interfaces;
using WebApi.Data;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository;

public class ChatGroupRepository : IChatGroupRepository
{
    private readonly DataContext _context;

    public ChatGroupRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ChatGroup?> GetChatGroup(Guid Id)
    {
        try
        {
            return await _context.ChatGroups.FirstOrDefaultAsync(cg => cg.Id == Id);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex);
            return null;
        }
    }

}