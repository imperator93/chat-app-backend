using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly DataContext _context;

    public MessageRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Message>> GetBroadcastMessages()
    {
        return await _context.Messages.Where(m => m.ChatGroupId == null).ToListAsync();
    }
}