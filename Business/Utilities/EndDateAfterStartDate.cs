
using Business.Models;
using System.ComponentModel.DataAnnotations;

//Custom validation attribute provided by ChatGPT4o.
namespace Business.Utilities
{
    public class EndDateAfterStartDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = (ProjectRegistrationModel)validationContext.ObjectInstance;

            if (model.EndDate.HasValue && model.EndDate <= model.StartDate)
            {
                return new ValidationResult("End date must be after start date.");
            }

            return ValidationResult.Success;
        }
    }
}
