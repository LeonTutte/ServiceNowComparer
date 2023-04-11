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
            // TODO: should not contain any spaces
            RuleFor(u => u.Label)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(u => u.Password)
            .NotEmpty();
        }
    }
}