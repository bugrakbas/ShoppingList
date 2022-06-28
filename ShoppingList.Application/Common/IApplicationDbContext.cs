using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Common
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Product> Products { get; }
        DbSet<Category> Categories { get; }
        DbSet<User> Users { get; }

    }
}
