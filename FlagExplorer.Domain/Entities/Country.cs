namespace FlagExplorer.Domain.Entities;

public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Capital { get; set; } = string.Empty;
    public long Population { get; set; }
    public string Flag { get; set; } = string.Empty;
}