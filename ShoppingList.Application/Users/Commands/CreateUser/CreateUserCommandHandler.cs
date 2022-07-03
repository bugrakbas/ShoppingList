using MediatR;
using ShoppingList.Application.Common.Interfaces.Repositories;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User()
            {
                FirstName = request.FirstName,
                SurName = request.SurName,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role
            };
            await _userRepository.Add(user);
            return user;
        }
    }
}
