using AutoMapper;
using ShopManager.Database.Model;
using ShopManager.Services.Model.DTO;

namespace ShopManager.Services.Model.Mapper
{
    public class ShopClientMapperProfile : Profile
    {
        public ShopClientMapperProfile()
        {
            CreateMap<ShopClient, ShopClientDTO>()
                .ForMember(dto => dto.DateOfBirth, options => options.MapFrom(m => m.DateOfBirth.ToShortDateString()))
                .ForMember(dto => dto.RegistrationDate, options => options.MapFrom(m => m.RegistrationDate.ToShortDateString()));

            CreateMap<ShopClientDTO, ShopClient>()
                .ForMember(m => m.DateOfBirth, options => options.MapFrom(dto => DateOnly.Parse(dto.DateOfBirth)))
                .ForMember(m => m.RegistrationDate, options => options.MapFrom(dto => DateOnly.Parse(dto.RegistrationDate)));
        }
    }
}
