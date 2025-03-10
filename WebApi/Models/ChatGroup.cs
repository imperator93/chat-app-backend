namespace WebApi.Models;

public class ChatGroup
{
    public Guid? Id { get; set; }

    public ICollection<User> Users { get; set; } = [];
    public ICollection<Message> Messages { get; set; } = [];
}