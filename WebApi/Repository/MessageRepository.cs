using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly DataContext _context;
    private readonly UserRepository _userRepository;
    private readonly ChatGroupRepository _chatGroupRepository;
    public MessageRepository(DataContext context, UserRepository userRepository, ChatGroupRepository chatGroupRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _chatGroupRepository = chatGroupRepository;
    }

    public async Task<ICollection<Message>> GetBroadcastMessages()
    {
        return await _context.Messages.Where(m => m.ChatGroupId == null).ToListAsync();
    }

    public async Task<Message?> CreateMessage(MessageRequestDto messageRequestDto)
    {
        var user = await _userRepository.GetUser(messageRequestDto.UserId);

        if (user is null) return null;

        var message = new Message()
        {
            Content = messageRequestDto.Content,
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            User = user,
            UserId = user.Id
        };

        if (messageRequestDto.ChatGroupId is null)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message;
        }

        var chatGroup = await _chatGroupRepository.GetChatGroup(messageRequestDto.ChatGroupId);

        if (chatGroup is not null)
        {
            message.ChatGroup = chatGroup;
            message.ChatGroupId = chatGroup.Id;

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message;
        }

        var newChatGroup = new ChatGroup()
        {
            Id = Guid.NewGuid(),
            Users = [],
            Messages = [],
        };

        message.ChatGroup = newChatGroup;
        message.ChatGroupId = newChatGroup.Id;

        newChatGroup.Messages.Add(message);
        newChatGroup.Users.Add(user);

        await _context.ChatGroups.AddAsync(newChatGroup);
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();

        return message;
    }

    public async Task<bool> DeleteMessage(MessageRequestDto messageRequestDto)
    {
        var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == messageRequestDto.Id);

        if (message is null) return false;

        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();

        return true;
    }
}