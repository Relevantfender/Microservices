using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles;

public class PlatformsProfile : Profile
{
  public PlatformsProfile()
  {
    CreateMap<Platform, PlatformReadDTO>().ReverseMap();
    CreateMap<Platform, PlatformCreateDTO>().ReverseMap();
  }
}
