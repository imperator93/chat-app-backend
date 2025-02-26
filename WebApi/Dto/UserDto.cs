namespace WebApi.Dto;

public record UserDto(
    Guid UserId,
    string Name,
    string Avatar,
    bool IsOnline
);