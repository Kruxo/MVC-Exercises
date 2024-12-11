using System.ComponentModel.DataAnnotations;


namespace MvcBasics.Models;
public class UserViewModel
{
    [Required(ErrorMessage = "Please enter a username")]
    public string Username { get; set; } = "";

    [Required(ErrorMessage = "Please enter a password")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "Please enter an email address")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = "";

    public string UsernameTaken { get; set; } = "";
}
