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
            RuleFor(u => u.Label)
                .NotEmpty()
                .MinimumLength(3)
                .Must(ShouldContainSpaces);

            RuleFor(u => u.Password)
            .NotEmpty();
        }

        protected bool ShouldContainSpaces(string label)
        {
            return label.All(Char.IsLetterOrDigit);
        }
    }
}