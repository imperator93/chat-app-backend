using AutoMapper;
using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserResponseDto>();
        CreateMap<Message, MessageResponseDto>();
    }
}