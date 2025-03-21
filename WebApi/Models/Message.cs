namespace WebApi.Models;

public class Message
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ChatGroupId { get; set; }
    //nav
    public User? User { get; set; }
    public ChatGroup? ChatGroup { get; set; }
}