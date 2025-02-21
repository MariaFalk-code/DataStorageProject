using System.ComponentModel.DataAnnotations;

namespace Business.Utilities;

public static class PromptAndValidate
{
    /// <summary>
    /// A utility method that prompts user input and validates it against the specified property of a given instance, using data annotation attributes.
    /// </summary>
    /// <param name="promptMessage">The promptmessage to display.</param>
    /// <param name="instance">An instance of the class containing the property to validate.</param>
    /// <param name="propertyName">The name of the property to validate.</param>
    /// <returns>The validated input provided by the user.</returns>
    /// Code from last project, modified by ChatGPT4o to function without a Result class. Needed a few iterations to function correctly.
    public static string Prompt(string promptMessage, object instance, string propertyName)
    {
        var property = instance.GetType().GetProperty(propertyName);
        if (property == null)
        {
            throw new ArgumentException($"Property '{propertyName}' not found on type '{instance.GetType().Name}'.");
        }

        var tempInstance = Activator.CreateInstance(instance.GetType());
        if (tempInstance == null)
        {
            throw new InvalidOperationException($"Cannot create an instance of type '{instance.GetType().Name}'. Ensure it has a parameterless constructor.");
        }

        Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType; // ✅ Handle nullable types

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine(promptMessage);
            string input = Console.ReadLine() ?? string.Empty;

            // 🔹 Handle empty input for nullable types
            if (string.IsNullOrWhiteSpace(input) && Nullable.GetUnderlyingType(property.PropertyType) != null)
            {
                return null!; // Return null for nullable properties
            }

            // 🔹 Convert input to correct data type
            object? convertedValue;
            try
            {
                if (propertyType == typeof(DateTime)) // Special case for DateTime
                {
                    convertedValue = DateTime.Parse(input);
                }
                else
                {
                    convertedValue = Convert.ChangeType(input, propertyType);
                }
            }
            catch
            {
                Console.WriteLine($"Invalid input. Expected type: {propertyType.Name}.");
                continue; // Ask again
            }

            // Assign converted value to temp instance for validation
            property.SetValue(tempInstance, convertedValue);

            var context = new ValidationContext(tempInstance) { MemberName = propertyName };
            var results = new List<ValidationResult>();

            if (Validator.TryValidateProperty(property.GetValue(tempInstance), context, results))
            {
                return input; // Input is valid!
            }

            Console.WriteLine(results[0].ErrorMessage);
            Console.WriteLine("Please try again.");
        }
    }

}



