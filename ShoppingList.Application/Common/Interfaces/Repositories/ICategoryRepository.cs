using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Common.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
