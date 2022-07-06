using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(r => r.FirstName)
                .MinimumLength(2)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(r => r.SurName)
                .MinimumLength(2)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(r => r.Email)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(r => r.Password)
                .MinimumLength(6)
                .MaximumLength(15)
                .NotEmpty();

        }
    }

}
