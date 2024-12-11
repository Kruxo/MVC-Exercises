using System.ComponentModel.DataAnnotations;


namespace MvcBasics.Models;


public class AppointmentViewModel
{
    [Required]
    [Display(Name = "Full name")]
    public string FullName { get; set; } = "";


    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";


    [Required]
    [DataType(DataType.Date)]
    [FutureDate(ErrorMessage = "The date must be in the future")]
    public DateTime Date { get; set; }


    [Required]
    [Display(Name = "Timeslot")]
    public string TimeSlot { get; set; } = "";


    public string AlreadyBookedTime { get; set; } = "";
}


public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateTime date)
        {
            return date > DateTime.Now;
        }
        return false;
    }
}
