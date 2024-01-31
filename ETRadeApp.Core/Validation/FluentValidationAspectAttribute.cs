using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class FluentValidationAspectAttribute : ActionFilterAttribute
{
    private readonly Type _validatorType;

    public FluentValidationAspectAttribute(Type validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new ArgumentException("This is not a valid validator type");
        }

        _validatorType = validatorType;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var validator = (IValidator)Activator.CreateInstance(_validatorType);
        var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
        var entities = context.ActionArguments.Values.Where(t => t.GetType() == entityType);

        foreach (var entity in entities)
        {
            var validationContext = new ValidationContext<object>(entity);
            var validationResult = validator.Validate(validationContext);

            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join("\n", validationResult.Errors.Select(error => error.ErrorMessage));
                context.Result = new BadRequestObjectResult(errorMessage);
                return;
            }
        }

        base.OnActionExecuting(context);
    }
}