namespace WebApi.Models;

public class ChatGroup
{
    public Guid Id { get; set; }

    public ICollection<UserGroup> UserGroups { get; set; } = [];
    public ICollection<MessageGroup> MessageGroups { get; set; } = [];
}