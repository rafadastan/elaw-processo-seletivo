using AutoMapper;
using elaw.Application.Dto;
using elaw.Application.DTOs;
using elaw.Domain.Entities;

namespace elaw.Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id != Guid.Empty ? src.Id : Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Address,
                       opt => opt.MapFrom(src => src.Address));


            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Address,
                       opt => opt.MapFrom(src => src.Address));
        }
    }
}
