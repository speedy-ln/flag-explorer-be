namespace FlagExplorer.Application.DTOs;

public class CountryDetailsDto
{
    public string Name { get; set; } = string.Empty;
    public string Capital { get; set; } = string.Empty;
    public long Population { get; set; }
    public string Flag { get; set; } = string.Empty;
}