using System.ComponentModel.DataAnnotations;

namespace WebUI.Attributes
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _conditionProperty;
        private readonly object _desiredValue;

        public RequiredIfAttribute(string conditionProperty, object desiredValue)
        {
            _conditionProperty = conditionProperty;
            _desiredValue = desiredValue;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var conditionProperty = validationContext.ObjectType.GetProperty(_conditionProperty);
            if (conditionProperty == null)
                return new ValidationResult($"Unknown property: {_conditionProperty}");

            var conditionValue = conditionProperty.GetValue(validationContext.ObjectInstance);

            if (conditionValue?.ToString() == _desiredValue.ToString() && value == null)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }

}
