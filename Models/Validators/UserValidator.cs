using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Password).MinimumLength(8).NotNull().NotEmpty().Must(x => x.Contains("#")).WithMessage("Password must contain #");
            RuleFor(x => x.Role).IsInEnum();
        }
    }
}
