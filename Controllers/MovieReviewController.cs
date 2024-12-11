using Microsoft.AspNetCore.Mvc;
using MvcBasics.Models;
using System.Text.Json;

namespace MvcBasics.Controllers;

// Controller to handle movie review actions
public class MovieReviewController : Controller
{
    // Displays the Create view (GET request)
    public IActionResult Create()
    {
        var model = new MovieReviewViewModel
        {
            SelectedGenres = new List<string>() // Ensure the list is initialized to avoid null reference errors
        };

        return View(model); // Pass the initialized model to the Create view
    }

    // Handles form submission (POST request)
    [HttpPost]
    public IActionResult Create(MovieReviewViewModel model)
    {
        // Validate that at least one genre is selected
        if (model.SelectedGenres == null || !model.SelectedGenres.Any())
        {
            // Add a validation error for the SelectedGenres property
            ModelState.AddModelError("SelectedGenres", "Please select at least one genre.");
        }

        // Check if the entire model is valid
        if (!ModelState.IsValid)
        {
            return View(model); // Re-display the form with validation errors
        }

        // Serialize the valid model to JSON and store it in TempData
        TempData["MovieReview"] = JsonSerializer.Serialize(model);

        // Redirect to the Confirmation action
        return RedirectToAction(nameof(Confirmation));
    }

    // Displays the Confirmation view
    public IActionResult Confirmation()
    {
        // Retrieve the serialized model from TempData
        var movieReviewJson = TempData["MovieReview"]?.ToString();

        // Redirect back to the Create action if no data is found
        if (string.IsNullOrEmpty(movieReviewJson))
        {
            return RedirectToAction(nameof(Create));
        }

        // Deserialize the JSON back into the view model
        var model = JsonSerializer.Deserialize<MovieReviewViewModel>(movieReviewJson);

        // Pass the deserialized model to the Confirmation view
        return View(model);
    }
}
