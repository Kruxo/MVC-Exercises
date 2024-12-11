using Microsoft.AspNetCore.Mvc;
using MvcBasics.Models;

namespace MvcBasics.Controllers;

public class CityController : Controller
{
    // Handles the Index action which initializes the view with the selected state and city.
    public IActionResult Index(string state = "", string city = "")
    {
        // Create the view model with provided state and city values.
        var model = new CityViewModel
        {
            SelectedState = state,
            SelectedCity = city
        };

        // Pass the model to the view.
        return View(model);
    }
}

/*
Summary of the Code
This project implements a simple Model-View-Controller (MVC) pattern for displaying state and city information along with their populations.

Key Components:
1. Model Layer
- City: Represents individual cities with their names and populations.
- State: Represents states with their names and a list of cities.
- CityViewModel: Serves as the intermediary between the controller and view, managing the list of states, cities, and population retrieval logic.

2.Controller Layer
- CityController: Handles requests and passes data (via the CityViewModel) to the view for rendering.

3. View Layer
- Index.cshtml: A dynamic UI allowing users to select a state and city from dropdown menus. It displays the population for the selected city, if applicable.

Workflow:
1. State Selection
- The user selects a state from a dropdown. This triggers a GET request, and the selected state is passed to the controller.
- The CityViewModel filters cities based on the selected state and populates the corresponding dropdown.

2. - City Selection
Once a state is selected, the city dropdown becomes available. The user selects a city, triggering another GET request with the selected state and city.

3. Population Display
- Based on the selected state and city, the CityViewModel retrieves and displays the population data in the view.

Key Points and Relationships:
- Models (City and State) define the structure of data.
- ViewModel (CityViewModel) handles data preparation, state management, and filtering.
Controller (CityController) directs traffic, initializing and supplying the view with the required model.
- View (Index.cshtml) provides a user interface for interaction and displays the results.

This separation of concerns ensures that each layer has a focused responsibility, making the code maintainable and scalable.
*/