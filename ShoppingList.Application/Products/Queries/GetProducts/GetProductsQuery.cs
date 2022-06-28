using MediatR;
using ShoppingList.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Product.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<List<ProductDto>>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = _productRepository.GetAll();

            var result = productList.Select(productDto => new ProductDto()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Feature = productDto.Feature,
                CategoryId = productDto.CategoryId,
            });

            return result.ToList();
        }
    }
}
