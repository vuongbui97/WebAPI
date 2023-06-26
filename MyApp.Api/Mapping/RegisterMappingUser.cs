using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyApp.DTOs.Users;

namespace MyApp.Mapping
{
    public class RegisterMappingUser : Profile
    {
        public RegisterMappingUser() 
        {
            CreateMap<UserRegisterDto, IdentityUser>()
                .ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
