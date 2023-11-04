#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models;

public class Encuesta{
    [MinLength(2, ErrorMessage = "The Name must be at least 2 characters.")]
    [Required(ErrorMessage = "The Name is required")]
    public string Name {get; set;}

    [Required(ErrorMessage = "The Ubication is required")]
    [RegularExpression("^(?!-).*", ErrorMessage = "The Ubication is required")]
    public string Location {get; set;}
    
    [Required(ErrorMessage = "Favorite Language is required")]
    [RegularExpression("^(?!-).*", ErrorMessage = "Favorite Language is required")]
    public string FavoriteLanguage {get; set;}

    [FutureDate]
    public DateTime Date {get; set;}



    [MinLength(20, ErrorMessage = "The comment must be at least 20 characters.")]
    public string? Comment {get; set;}
}


public class FutureDateAttribute : ValidationAttribute{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext){
        if (value != null){
            DateTime Date = (DateTime)value;
            if (Date > DateTime.Now){
                return new ValidationResult("This field should't contain a future date");
            }
        }
        return ValidationResult.Success;
    }
}