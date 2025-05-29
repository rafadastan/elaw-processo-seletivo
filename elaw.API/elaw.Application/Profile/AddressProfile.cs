using AutoMapper;
using elaw.Application.Dto;
using elaw.Domain.Entities;

namespace elaw.Application.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src =>
                            src.Id != Guid.Empty ? src.Id : Guid.NewGuid()))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Customer, opt => opt.Ignore()); 

           
            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode));
        }
    }
}
