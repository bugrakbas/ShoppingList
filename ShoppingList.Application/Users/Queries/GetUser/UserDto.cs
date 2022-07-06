using ShoppingList.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Users.Queries.GetUser
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Roles Role { get; set; }
    }
}
