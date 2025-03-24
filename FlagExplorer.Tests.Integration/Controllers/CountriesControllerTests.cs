using System.Net.Http.Json;
using FlagExplorer.Application.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace FlagExplorer.Tests.Integration.Controllers;

public class CountriesControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CountriesControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    
    [Fact]
    public async Task GetAllCountries_ReturnListOfCountries()
    {
        var response = await _client.GetAsync("/countries");
        response.EnsureSuccessStatusCode();

        var countries = await response.Content.ReadFromJsonAsync<IEnumerable<CountryDto>>();
        countries.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetCountryByName_ShouldReturnCountryDetails()
    {
        var response = await _client.GetAsync("/countries/South Africa");
        response.EnsureSuccessStatusCode();

        var country = await response.Content.ReadFromJsonAsync<CountryDetailsDto>();
        country.Should().NotBeNull();
        country!.Name.Should().Be("South Africa");
    }

    [Fact]
    public async Task GetCountryByName_ShouldReturnEmpty_WhenNotFound()
    {
        var response = await _client.GetAsync("/countries/Narnia");
        response.EnsureSuccessStatusCode();
        
        var country = await response.Content.ReadFromJsonAsync<CountryDetailsDto>();
        country.Should().NotBeNull();
    }
}