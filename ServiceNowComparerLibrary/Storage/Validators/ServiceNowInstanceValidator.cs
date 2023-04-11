using FluentValidation;

using ServiceNowComparerLibrary.Storage.Models;

namespace ServiceNowComparerLibrary.Storage.Validators
{
    public class ServiceNowInstanceValidator : AbstractValidator<ServiceNowInstance>
    {
        public ServiceNowInstanceValidator()
        {
            RuleFor(sni => sni.Label)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(sni => sni.Url)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}