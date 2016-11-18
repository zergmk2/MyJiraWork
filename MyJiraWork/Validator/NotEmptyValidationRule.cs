using System.Globalization;
using System.Windows.Controls;

namespace MyJiraWork.Validator
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrEmpty((value ?? "").ToString())
                ? new ValidationResult(false, "Field can't be empty!") : ValidationResult.ValidResult;
        }
    }
}
