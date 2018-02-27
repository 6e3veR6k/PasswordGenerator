using System.Globalization;
using System.Windows.Controls;

namespace PasswordGenerator
{
    public class StringToIntValidationRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out var result))
            {
                return result > 0 ? new ValidationResult(true, null) : new ValidationResult(false, "Please enter positive integer value."); ;
            }
            return new ValidationResult(false, "Please enter a valid integer value.");
        }
    }
}