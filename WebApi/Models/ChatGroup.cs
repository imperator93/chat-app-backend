namespace WebApi.Models;

public class ChatGroup
{
    public Guid Id { get; set; }

    public ICollection<User> UserGroups { get; set; } = [];
    public ICollection<Message> MessageGroups { get; set; } = [];
}