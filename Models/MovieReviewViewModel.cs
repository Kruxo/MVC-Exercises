using System.ComponentModel.DataAnnotations;

namespace MvcBasics.Models
{
    [Serializable] // Indicates that the model can be serialized (useful for TempData storage)
    public class MovieReviewViewModel
    {
        [Required(ErrorMessage = "Please enter the movie title")]
        [Display(Name = "Movie Title")] // Custom display name for the property
        public string MovieTitle { get; set; } = ""; // Default value to avoid null references

        [Display(Name = "Genres")]
        [MinLength(1, ErrorMessage = "Please select at least one genre")]
        public List<string> SelectedGenres { get; set; } = new List<string>(); // Initialize the list to avoid null references

        [Required] // Makes the Rating field required
        [Range(1, 5, ErrorMessage = "Please select a rating between 1 and 5.")] // Enforces a range for valid ratings
        [Display(Name = "Rating (1-5)")]
        public int Rating { get; set; } = 3;

        [Required] // Makes the Review field required
        [MinLength(10, ErrorMessage = "Review must be at least 10 characters")] // Enforces a minimum length for the review text
        public string Review { get; set; } = ""; // Default value to avoid null references

        [Display(Name = "Would recommend")]
        public bool Recommend { get; set; } // Indicates whether the movie is recommended or not
    }
}
