using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            ValidationContext<object> validationContext = new ValidationContext<object>(entity);
            var result = validator.Validate(validationContext);
            if (result.IsValid == false)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
