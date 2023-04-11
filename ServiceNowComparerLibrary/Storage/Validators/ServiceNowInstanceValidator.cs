using FluentValidation;

using ServiceNowComparerLibrary.Storage.Models;

namespace ServiceNowComparerLibrary.Storage.Validators
{
    public class ServiceNowInstanceValidator : AbstractValidator<ServiceNowInstance>
    {
        public ServiceNowInstanceValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(sni => sni.Label)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .MinimumLength(3).WithMessage("{PropertyName} is less than 3 characters");

            RuleFor(sni => sni.Url)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .MinimumLength(3).WithMessage("{PropertyName} is less than 3 characters");
        }
    }
}