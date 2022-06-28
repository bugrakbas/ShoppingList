using MediatR;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime UpdatedDate { get; init; }

    }
}
