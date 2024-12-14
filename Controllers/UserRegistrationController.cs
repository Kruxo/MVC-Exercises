using Microsoft.AspNetCore.Mvc;
using MvcBasics.Models;

namespace MvcBasics.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: Registration Form
        public IActionResult Register()
        {
            return View(new UserRegistrationViewModel());
        }

        // POST: Process Registration
        [HttpPost]
        public IActionResult Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Process registration (save to database, etc.)
            TempData["Message"] = "Registration successful!";
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
