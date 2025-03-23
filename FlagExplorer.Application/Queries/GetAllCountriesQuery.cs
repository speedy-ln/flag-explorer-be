using FlagExplorer.Application.DTOs;
using MediatR;

namespace FlagExplorer.Application.Queries;

public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDto>>
{
    
}