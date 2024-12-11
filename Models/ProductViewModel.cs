using System.ComponentModel.DataAnnotations;

namespace MvcBasics.Models
{
    [Serializable]
    // Model to represent the product data with validation rules
    public class ProductViewModel
    {
        [Required(ErrorMessage = "The Product name field is required")] // Validation: required field
        [Display(Name = "Product name")] // Display name for form labels
        public string ProductName { get; set; } = "";

        [Required] // Validation: required field
        [Range(1, double.MaxValue, ErrorMessage = "Must be at least 1")] // Validation: minimum value
        public decimal Price { get; set; }

        [Required] // Validation: required field
        [MaxLength(20)] // Validation: max length of 20 characters
        public string Description { get; set; } = "";

        [Required] // Validation: required field
        public string Category { get; set; } = "";

        // Custom field for displaying "product already exists" error
        public string ProductAlreadyExist { get; set; } = "";
    }
}
