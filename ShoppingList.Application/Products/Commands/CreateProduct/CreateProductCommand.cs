using MediatR;
using ShoppingList.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Product.Commands.CreateProduct
{
    public record CreateProductCommand : IRequest<Domain.Entities.Product>
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
        public string Feature { get; init; }
        public bool IsReceived { get; init; }
        public Mesures Mesures { get; init; }
        public int CategoryId { get; init; }
    }
}
