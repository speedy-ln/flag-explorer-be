using FlagExplorer.Application.DTOs;
using FlagExplorer.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlagExplorerBE.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieve details about a specific country
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet("{name}")]
    [ProducesResponseType(typeof(CountryDetailsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByName(string name)
    {
        var result = await _mediator.Send(new GetCountryByNameQuery(name));
        return Ok(result ?? new CountryDetailsDto());
    }

    /// <summary>
    /// Retrieve all countries
    /// </summary>
    /// <returns>List of countries</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CountryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCountriesQuery());
        return Ok(result);
    }
}