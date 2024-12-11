namespace MvcBasics.Models;

public class CityViewModel
{
    // The currently selected state.
    public string? SelectedState { get; set; }

    // The currently selected city.
    public string? SelectedCity { get; set; }

    // List of states and their respective cities.
    private readonly List<State> _states =
    [
        new State("California",
        [
            new("Los Angeles", 3898747),
            new("San Francisco", 873965),
            new("San Diego", 1386932)
        ]),
        new State("New York",
        [
            new("New York City", 8804190),
            new("Buffalo", 278349),
            new("Albany", 99224)
        ]),
        new State("Texas",
        [
            new("Houston", 2313000),
            new("Austin", 961855),
            new("Dallas", 1331000)
        ])
    ];

    // Get a list of all state names.
    public List<string> States => _states.Select(s => s.Name).ToList();

    // Get a list of city names for the currently selected state.
    public List<string> CitiesForState()
    {
        if (SelectedState == null)
        {
            return [];
        }

        // Find the selected state.
        var state = _states.FirstOrDefault(s => s.Name == SelectedState);
        if (state == null)
        {
            return [];
        }

        // Return the list of city names.
        return state.Cities.Select(c => c.Name).ToList();
    }

    // Get the population of the selected city in the selected state.
    public int? GetPopulation()
    {
        if (string.IsNullOrEmpty(SelectedState) || string.IsNullOrEmpty(SelectedCity))
        {
            return null;
        }

        // Find the selected state.
        var state = _states.FirstOrDefault(s => s.Name == SelectedState);
        if (state == null)
        {
            return null;
        }

        // Find the selected city and return its population.
        var city = state.Cities.FirstOrDefault(c => c.Name == SelectedCity);
        //var city = state?.Cities.FirstOrDefault(c => c.Name == SelectedCity); //We can write this instead of checking if state == null above
        return city?.Population;
    }
}

