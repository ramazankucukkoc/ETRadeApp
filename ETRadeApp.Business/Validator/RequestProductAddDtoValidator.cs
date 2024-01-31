using ETRadeApp.Business.Dtos.Product;
using FluentValidation;

namespace ETRadeApp.Business.Validator
{
    public class RequestProductAddDtoValidator : AbstractValidator<RequestProductAddDto>
    {
        public RequestProductAddDtoValidator()
        {
            RuleFor(request => request.Name).NotEmpty().MaximumLength(50);
            RuleFor(request => request.UnitPrice).GreaterThan(0);
        }
    }
}