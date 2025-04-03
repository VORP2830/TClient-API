using AutoMapper;
using Clients.Domain.Entities;

namespace Clients.Application.DTOs.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}