using Microsoft.AspNetCore.Mvc;
using MvcBasics.Models;
using System.Text.Json;

namespace MvcBasics.Controllers;

// Controller to handle product-related actions
public class ProductController : Controller
{
    // Displays the Register view (GET request)
    public IActionResult Register()
    {
        return View();
    }

    // Handles the form submission from the Register view (POST request)
    [HttpPost]
    public IActionResult Register(ProductViewModel model)
    {
        // Check if the submitted form data is valid
        if (!ModelState.IsValid)
        {
            // If invalid, redisplay the form with validation messages
            return View(model);
        }

        // Check for a specific condition: if the product already exists
        if (model.ProductName == "ExistingProduct")
        {
            // Add a custom error message to ModelState
            ModelState.AddModelError("ProductAlreadyExist", "The product is already registred");
            return View(model); // Redisplay the form with the error
        }

        // Serialize the valid product data into TempData for temporary storage
        TempData["Product"] = JsonSerializer.Serialize(model);

        // Redirect to the Confirmation action
        return RedirectToAction(nameof(Confirmation));
    }

    // Displays the Confirmation view after successful product registration
    public IActionResult Confirmation()
    {
        // Retrieve the serialized product data from TempData
        var productJson = TempData["Product"]?.ToString();

        // If no product data is found, redirect to the Register view
        if (productJson == null)
        {
            return RedirectToAction(nameof(Register));
        }

        // Deserialize the product data back into a ProductViewModel object
        var model = JsonSerializer.Deserialize<ProductViewModel>(productJson);

        // Pass the product data to the Confirmation view
        return View(model);
    }
}
