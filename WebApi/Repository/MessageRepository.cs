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

    public ICollection<Message> GetMessages()
    {
        return [.. _context.Messages.OrderBy(m => m.CreatedAtDateTime)];
    }
}