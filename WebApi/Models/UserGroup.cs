namespace WebApi.Models;

//junction table
public class UserGroup
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ChatGroupId { get; set; }

    public User? User { get; set; }
    public ChatGroup? ChatGroup { get; set; }
}