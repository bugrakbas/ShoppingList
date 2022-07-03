using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<Domain.Entities.User>
    {
        public string FirstName { get; init; }

        public string SurName { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public string Role { get; init; }
    }
}
