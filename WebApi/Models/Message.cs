namespace WebApi.Models;

public class Message
{
    public Guid MessageId { get; set; }
    public string? Content { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAtDateTime { get; set; }

}
