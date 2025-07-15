using System.ComponentModel.DataAnnotations;

namespace WebUI.Attributes
{
    public class TimeSpanGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public TimeSpanGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (comparisonProperty == null)
                return new ValidationResult($"Unknown property: {_comparisonProperty}");

            var comparisonValue = (TimeSpan?)comparisonProperty.GetValue(validationContext.ObjectInstance);
            var currentValue = (TimeSpan?)value;

            if (comparisonValue.HasValue && currentValue.HasValue && currentValue <= comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }

}
