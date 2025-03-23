using FlagExplorer.Domain.Entities;

namespace FlagExplorer.Application.Interfaces;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<Country?> GetByNameAsync(string name);
}