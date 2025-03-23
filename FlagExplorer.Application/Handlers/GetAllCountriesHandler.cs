using AutoMapper;
using FlagExplorer.Application.DTOs;
using FlagExplorer.Application.Interfaces;
using FlagExplorer.Application.Queries;
using MediatR;

namespace FlagExplorer.Application.Handlers;

public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDto>>
{
    private readonly ICountryRepository _repository;
    private readonly IMapper _mapper;
    
    public GetAllCountriesHandler(ICountryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CountryDto>>(countries);
    }
}