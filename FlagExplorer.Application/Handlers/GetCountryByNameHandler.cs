using AutoMapper;
using FlagExplorer.Application.DTOs;
using FlagExplorer.Application.Interfaces;
using FlagExplorer.Application.Queries;
using MediatR;

namespace FlagExplorer.Application.Handlers;

public class GetCountryByNameHandler : IRequestHandler<GetCountryByNameQuery, CountryDto?>
{
    private readonly ICountryRepository _repository;
    private readonly IMapper _mapper;

    public GetCountryByNameHandler(ICountryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CountryDto?> Handle(GetCountryByNameQuery request, CancellationToken cancellationToken)
    {
        var country = await _repository.GetByNameAsync(request.Name);
        return country is null ? null :  _mapper.Map<CountryDto>(country);
    }
}