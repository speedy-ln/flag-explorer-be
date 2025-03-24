using FlagExplorer.Application.DTOs;
using MediatR;

namespace FlagExplorer.Application.Queries;

public class GetCountryByNameQuery(string name) : IRequest<CountryDetailsDto?>
{
    public string Name { get; set; } = name;
}