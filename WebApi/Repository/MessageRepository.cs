using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    // CONTINUE HERE
    public async Task<Message?> CreateMessage(MessageRequestDto messageRequestDto)
    {
        var user = await _userRepository.GetUser(messageRequestDto.UserId);
        var chatGroup = await _chatGroupRepository.GetChatGroup(messageRequestDto.ChatGroupId);

        if (user is null) return null;

        if (chatGroup is null)
        {
            var newChatGroup = new ChatGroup()
            {
                Id = messageRequestDto.ChatGroupId,
                Messages = [],
                Users = [],
            };

            await _context.ChatGroups.AddAsync(newChatGroup);

            var message = new Message()
            {
                ChatGroup = chatGroup ?? newChatGroup,
                ChatGroupId = chatGroup.Id ?? newChatGroup.Id,
                Content = messageRequestDto.Content,
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                User = user,
                UserId = user.Id
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message;
        }
    }

}