namespace WebApi.Dto;

public record MessageRequestDto(
    Guid UserId,
    Guid? ChatGroupId,
    string Content
);

public record MessageResponseDto(
    Guid UserId,
    Guid ChatGroupId,
    DateTime CreatedAt
);