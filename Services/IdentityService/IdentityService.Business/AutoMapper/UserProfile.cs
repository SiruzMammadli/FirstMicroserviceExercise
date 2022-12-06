using AutoMapper;
using Common.Core.Entities;
using static IdentityService.Entities.DTOs.UserDto;

namespace IdentityService.Business.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<GetUserByEmailDto, User>().ReverseMap();
        }
    }
}
