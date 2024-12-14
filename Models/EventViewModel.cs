using System.ComponentModel.DataAnnotations;

namespace MvcBasics.Models;

public class EventViewModel
{
    // Event name.
    [Required]
    [Display(Name = "Event Name")]
    [StringLength(100, MinimumLength = 5)]
    public string Name { get; set; }

    // Organizer's email.
    [Required]
    [EmailAddress]
    [Display(Name = "Organizer Email")]
    public string OrganizerEmail { get; set; }

    // Event date.
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Event Date")]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Event type (dropdown).
    [Required]
    [EnumDataType(typeof(EventType))]
    [Display(Name = "Event Type")]
    public EventType Type { get; set; }

    // Estimated number of attendees (numeric range).
    [Required]
    [Range(10, 1000)]
    [Display(Name = "Expected Attendees")]
    public int Attendees { get; set; }

    // Event website (optional).
    [Url]
    [Display(Name = "Event Website")]
    public string? Website { get; set; }

    // Agreement checkbox.
    [Required]
    [Display(Name = "Agree to terms and conditions")]
    public bool AgreeToTerms { get; set; }
}

// Enum for Event Types.
public enum EventType
{
    Conference,
    Workshop,
    Meetup,
    Webinar
}
