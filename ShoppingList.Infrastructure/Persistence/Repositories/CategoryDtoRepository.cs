using ShoppingList.Application.Common.Interfaces.Repositories;
using ShoppingList.Domain.DTOs;
using ShoppingList.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Infrastructure.Persistence.Repositories
{
    public class CategoryDtoRepository : GenericRepository<CategoryDtos>, ICategoryDtoRepository
    {
        public CategoryDtoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

    }
}
