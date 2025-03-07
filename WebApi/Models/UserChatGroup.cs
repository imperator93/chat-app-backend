namespace WebApi.Models;

//JUNCTION
public class UserChatGroup
{
    public Guid UserId { get; set; }
    public Guid ChatGroupId { get; set; }

    public User? User { get; set; }
    public ChatGroup? ChatGroup { get; set; }
}
