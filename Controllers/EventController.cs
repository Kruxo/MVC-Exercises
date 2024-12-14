using Microsoft.AspNetCore.Mvc;
using MvcBasics.Models;

namespace MvcBasics.Controllers;

public class EventController : Controller
{
    // Displays the event creation form.
    public IActionResult Index()
    {
        return View(new EventViewModel());
    }

    // Handles form submission.
    [HttpPost]
    public IActionResult Index(EventViewModel model)
    {
        if (ModelState.IsValid)
        {
            // In a real-world app, save the event data to the database.
            ViewBag.Message = "Event created successfully!";
            return View("Success", model);
        }

        // If validation fails, redisplay the form with validation messages.
        return View(model);
    }
}