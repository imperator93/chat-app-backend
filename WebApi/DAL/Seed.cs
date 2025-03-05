using WebApi.Data;
using WebApi.Models;

namespace WebApi.DAL;

public class Seed
{
    private readonly DataContext _dataContext;

    public Seed(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void SeedDataContext()
    {
        if (!_dataContext.Users.Any())
        {
            List<User> users = [
                new User() {
                    Name = "Leo",
                    Password = "12345",
                    Avatar = "avatarLeo",
                    IsOnline = false,
                    Id = new Guid(),
                },
                new User() {
                    Name = "Asy",
                    Password = "12345",
                    Avatar = "avatarAsy",
                    IsOnline = false,
                    Id = new Guid(),
                },
                new User() {
                    Name = "Charlie",
                    Password = "12345",
                    Avatar = "avatarCharlie",
                    IsOnline = false,
                    Id = new Guid(),
                }
            ];

            _dataContext.Users.AddRange(users);
            _dataContext.SaveChanges();
        }

        if (!_dataContext.Messages.Any())
        {
            List<Message> messages = [
                new Message() {
                    UserId = new Guid(),
                    Id = new Guid(),
                    Content = "oogjeoigjsjgj ijsiaJGH FIHAPHF DAHJ",
                    CreatedAtDateTime = new DateTime(),
                },
                new Message() {
                    UserId = new Guid(),
                    Id = new Guid(),
                    Content = "oogjeoigjsjgj ijsiaJGH FIHAPHF DAHJ",
                    CreatedAtDateTime = new DateTime(),
                },
                new Message() {
                    UserId = new Guid(),
                    Id = new Guid(),
                    Content = "oogjeoigjsjgj ijsiaJGH FIHAPHF DAHJ",
                    CreatedAtDateTime = new DateTime(),
                }
           ];

            _dataContext.Messages.AddRange(messages);
            _dataContext.SaveChanges();
        }

    }

}