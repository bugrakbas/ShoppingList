using MediatR;
using ShoppingList.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<Domain.Entities.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product()
            {
                Name = request.Name,
                Price = request.Price,
                Feature = request.Feature,
                CategoryId = request.CategoryId,
                IsReceived = request.IsReceived,
                Mesures = request.Mesures
            };
            await _productRepository.Add(product);

            return product;

        }
    }
}
