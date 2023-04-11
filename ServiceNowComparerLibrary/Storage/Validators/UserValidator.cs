using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;

using ServiceNowComparerLibrary.Storage.Models;

namespace ServiceNowComparerLibrary.Storage.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(u => u.Label)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .MinimumLength(3).WithMessage("{PropertyName} is less than 3 characters")
                .Must(ShouldContainSpaces).WithMessage("{PropertyName} contains whitespace's");

            RuleFor(u => u.Password)
            .NotEmpty().WithMessage("{PropertyName} is Empty");
        }

        protected bool ShouldContainSpaces(string label)
        {
            return label.All(Char.IsLetterOrDigit);
        }
    }
}