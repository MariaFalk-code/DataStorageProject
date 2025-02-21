using System.ComponentModel.DataAnnotations;

namespace Business.Utilities
{
    public static class PromptAndValidate
    {
        /// <summary>
        /// A utility method that prompts user input and validates it against the specified property of a given instance, using data annotation attributes.
        /// </summary>
        /// <param name="promptMessage">The promptmessage to display.</param>
        /// <param name="instance">An instance of the class containing the property to validate.</param>
        /// <param name="propertyName">The name of the property to validate.</param>
        /// <returns>The validated input provided by the user.</returns>
        /// Code from last project, modified by ChatGPT4o to function without a Result class.
        public static string Prompt(string promptMessage, object instance, string propertyName)
        {
            var property = instance.GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Property {propertyName} not found on type {instance.GetType().Name}");
            }
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(promptMessage);
                string input = Console.ReadLine() ?? string.Empty;

                var tempInstance = Activator.CreateInstance(instance.GetType());
                if (tempInstance == null)
                {
                    throw new InvalidOperationException($"Cannot create an instance of type '{instance.GetType().Name}'. Ensure it has a parameterless constructor.");
                }
                property.SetValue(tempInstance, input);

                var context = new ValidationContext(tempInstance) { MemberName = propertyName };
                var results = new List<ValidationResult>();

                if (Validator.TryValidateProperty(property.GetValue(tempInstance), context, results))
                {
                    return input;
                }

                Console.WriteLine(results[0].ErrorMessage);
                Console.WriteLine("Please try again.");
            }
        }
    }
}
