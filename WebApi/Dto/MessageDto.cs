namespace WebApi.Dto;

public record MessageRequestDto(
    Guid? Id,
    Guid UserId,
    string Content,
    Guid? ChatGroupId
);

public record MessageResponseDto(
    Guid Id,
    string Content,
    DateTime CreatedAt,
    Guid UserId,
    Guid ChatGroupId,
    bool MessageDeleted
);