using Microsoft.AspNetCore.Mvc;
using MvcBasics.Models;


namespace MvcBasics.Controllers;


public class UserController : Controller
{


    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Register(UserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.Username == "existinguser")
        {
            ModelState.AddModelError("UsernameTaken", "The username is already taken");
            return View(model);
        }

        return View("ThankYou", model);
    }


}
