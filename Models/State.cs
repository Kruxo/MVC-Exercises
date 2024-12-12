namespace MvcBasics.Models;

// Represents a state with a name and a list of cities
public class State(string name, List<City> cities) //Using primary constructor and also properties from City.cs in our list
{
    public string Name { get; } = name;
    public List<City> Cities { get; } = cities;
}
