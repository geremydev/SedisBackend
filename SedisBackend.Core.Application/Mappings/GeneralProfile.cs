using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Users;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            CreateMap<AuthenticationRequest, LoginDto>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserDto>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<ForgotPasswordRequest, ForgotPasswordDto>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();




            CreateMap<ResetPasswordRequest, ResetPasswordDto>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();




            #region Mapeo de Pacientes

            CreateMap<BasePatientDto, SavePatientDto>()
                .ReverseMap();
                //.ForMember(x => x.ClinicalHistories, opt => opt.Ignore())
                //.ForMember(x => x.Appointments, opt => opt.Ignore())
                //.ForMember(x => x.Allergies, opt => opt.Ignore())
                //.ForMember(x => x.Illnesses, opt => opt.Ignore())
                //.ForMember(x => x.Discapacities, opt => opt.Ignore())
                //.ForMember(x => x.RiskFactors, opt => opt.Ignore())
                //.ForMember(x => x.Vaccines, opt => opt.Ignore())
                //.ForMember(x => x.FamilyHistories, opt => opt.Ignore());


            CreateMap<Patient, SavePatientDto>()
                .ReverseMap();


            CreateMap<Patient, BasePatientDto>()
                .ReverseMap();

            #endregion
        }
    }
}
