
using Business.Models;
using System.ComponentModel.DataAnnotations;

//Custom validation attribute provided by ChatGPT4o. Needed a few iterations to function correctly.
namespace Business.Utilities
{
    public class EndDateAfterStartDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = (ProjectRegistrationModel)validationContext.ObjectInstance;

            if (!model.EndDate.HasValue) return ValidationResult.Success;  // ✅ Allow null EndDate

            if (model.EndDate.Value <= model.StartDate)
            {
                return new ValidationResult("End date must be after start date.");
            }

            return ValidationResult.Success;
        }
    }
}



