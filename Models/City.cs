namespace MvcBasics.Models;

// Represents a city with a name and population.
public class City(string name, int population)
{
    public string Name { get; } = name;
    public int Population { get; } = population;
}
