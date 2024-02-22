using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformProfile: Profile
{
    public PlatformProfile()
    {
        CreateMap<Platform,PlatformReadDto>();
        CreateMap<PlatformCreateDto,Platform>();
    }
}