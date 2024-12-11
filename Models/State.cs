namespace MvcBasics.Models;

// Represents a state with a name and a list of cities
public class State(string name, List<City> cities)
{
    public string Name { get; } = name;
    public List<City> Cities { get; } = cities;
}
