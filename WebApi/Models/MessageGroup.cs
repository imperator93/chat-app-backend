namespace WebApi.Models;

public class MessageGroup
{
    public Guid Id { get; set; }
    public Guid ChatGroupId { get; set; }
    public ChatGroup ChatGroup { get; set; }
    public ICollection<Message> Messages { get; set; } = [];
}