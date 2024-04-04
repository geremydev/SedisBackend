using AutoMapper;
using SedisBackend.Core.Application.Dtos.Account;
using SedisBackend.Core.Application.Dtos.Users;

namespace SedisBackend.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();




            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();




            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();




            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
