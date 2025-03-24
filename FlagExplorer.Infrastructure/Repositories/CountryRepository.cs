using FlagExplorer.Application.Interfaces;
using FlagExplorer.Domain.Entities;

namespace FlagExplorer.Infrastructure.Repositories;

public class CountryRepository : ICountryRepository
{
    private static readonly List<Country> Countries = new()
    {
        new Country { Id = Guid.NewGuid(), Name = "South Africa", Capital = "Pretoria", Population = 60000000, Flag = "za" },
        new Country { Id = Guid.NewGuid(), Name = "Nigeria", Capital = "Abuja", Population = 206000000, Flag = "NG"},
        new Country { Id = Guid.NewGuid(), Name = "Kenya", Capital = "Nairobi", Population = 53700000, Flag = "KE" },
        new Country { Id = Guid.NewGuid(), Name = "Egypt", Capital = "Cairo", Population = 102000000, Flag = "EG" },
        new Country { Id = Guid.NewGuid(), Name = "United States", Capital = "Washington, D.C.", Population = 331000000, Flag = "US" },
        new Country { Id = Guid.NewGuid(), Name = "United Kingdom", Capital = "London", Population = 68200000, Flag = "UK" },
    };
    
    public Task<IEnumerable<Country>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Country>>(Countries);
    }

    public Task<Country?> GetByNameAsync(string name)
    {
        var country = Countries.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult<Country?>(country);
    }
}