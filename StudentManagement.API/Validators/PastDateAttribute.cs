using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.Validators;

public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date && date >= DateTime.Now)
        {
            return new ValidationResult(ErrorMessage ?? "Date must be in the past");
        }
        return ValidationResult.Success;
    }
}