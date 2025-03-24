using AutoMapper;
using FlagExplorer.Application.Handlers;
using FlagExplorer.Application.Interfaces;
using FlagExplorer.Application.MappingProfiles;
using FlagExplorer.Application.Queries;
using FlagExplorer.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace FlagExplorer.Tests.Unit.Handlers;

public class GetCountryByNameHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICountryRepository> _mockRepository;

    public GetCountryByNameHandlerTests()
    {
        var config = new MapperConfiguration(c => c.AddProfile<CountryProfile>());
        _mapper = config.CreateMapper();
        _mockRepository = new Mock<ICountryRepository>();
    }

    [Fact]
    public async Task Handle_ShouldReturnCountry_WhenCountryExists()
    {
        var country = new Country()
        {
            Name = "South Africa",
            Capital = "Pretoria",
            Population = 60000000,
            Flag = "ZA"
        };
        
        _mockRepository.Setup(repo => repo.GetByNameAsync(country.Name)).ReturnsAsync(country);
        var handler = new GetCountryByNameHandler(_mockRepository.Object, _mapper);

        var result = await handler.Handle(new GetCountryByNameQuery("South Africa"), CancellationToken.None);
        result.Should().NotBeNull();
        result!.Name.Should().Be(country.Name);
        result.Capital.Should().Be(country.Capital);
        result.Population.Should().Be(country.Population);
        result.Flag.Should().Be(country.Flag);
    }

    [Fact]
    public async Task Handle_ShouldReturnNull_WhenCountryDoesNotExist()
    {
        _mockRepository.Setup(repo => repo.GetByNameAsync("Narnia")).ReturnsAsync((Country?)null);
        var handler = new GetCountryByNameHandler(_mockRepository.Object, _mapper);
        
        var result = await handler.Handle(new GetCountryByNameQuery("Narnia"), CancellationToken.None);
        result.Should().BeNull();
    }
}