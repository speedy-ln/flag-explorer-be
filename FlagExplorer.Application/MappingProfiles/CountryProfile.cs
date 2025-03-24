using AutoMapper;
using FlagExplorer.Application.DTOs;
using FlagExplorer.Domain.Entities;

namespace FlagExplorer.Application.MappingProfiles;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<Country, CountryDetailsDto>();
    }
}