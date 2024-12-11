using Microsoft.AspNetCore.Mvc;
using MvcBasics.Models;


namespace MvcBasics.Controllers;


public class AppointmentController : Controller
{
    public IActionResult Book()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Book(AppointmentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }


        if (model.TimeSlot == "09:00-10:00" && model.Date.Date == new DateTime(2025, 1, 1))
        {
            ModelState.AddModelError("AlreadyBookedTime", "Sorry, this time is already booked.");
            return View(model);
        }

        return View("Confirmation", model);
    }


}
