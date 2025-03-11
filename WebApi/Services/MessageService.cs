using AutoMapper;
using WebApi.Dto;
using WebApi.Interfaces;

namespace WebApi.Services;

public class MessageService : IMessageService
{
    private readonly IMapper _mapper;
    private readonly IMessageRepository _messageRepository;
    public MessageService(IMapper mapper, IMessageRepository messageRepository)
    {
        _mapper = mapper;
        _messageRepository = messageRepository;
    }
    public async Task<IEnumerable<MessageResponseDto>> GetAllMessagesAsync()
    {
        return _mapper.Map<List<MessageResponseDto>>(await _messageRepository.GetBroadcastMessages());
    }

    public async Task<MessageResponseDto> CreateMessageAsync(MessageRequestDto messageRequestDto)
    {
        return _mapper.Map<MessageResponseDto>(await _messageRepository.CreateMessage(messageRequestDto));
    }

    public async Task<bool> DeleteMessageAsync(MessageRequestDto messageRequestDto)
    {
        return await _messageRepository.DeleteMessage(messageRequestDto);
    }

}