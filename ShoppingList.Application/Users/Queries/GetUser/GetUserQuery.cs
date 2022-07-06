using MediatR;
using ShoppingList.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Users.Queries.GetUser
{
    public record GetUserQuery : IRequest<List<UserDto>>
    {
    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<UserDto>>
    {

        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var userList = _userRepository.GetAll();

            var result = userList.Select(userDto => new UserDto()
            {
                FirstName = userDto.FirstName,
                SurName = userDto.SurName,
                Email = userDto.Email,
                Password = userDto.Password,
                Role = userDto.Role
            });

            return result.ToList();
        }
    }


}
