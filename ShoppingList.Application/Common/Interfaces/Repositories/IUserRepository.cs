using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<ShoppingList.Domain.Entities.User>
    {
    }
}
