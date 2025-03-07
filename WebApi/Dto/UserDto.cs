namespace WebApi.Dto;

public record UserRequestDto(
    string Name,
    string Password,
    string Avatar
);

public record UserResponseDto(
    Guid UserId,
    string Name,
    string Avatar,
    bool IsOnline
);