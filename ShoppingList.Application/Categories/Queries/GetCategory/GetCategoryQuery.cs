using MediatR;
using ShoppingList.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Categories.Queries.GetCategory
{
    public record GetCategoryQuery : IRequest<List<CategoryDto>>
    {
    }
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryList = _categoryRepository.GetAll();
            var result = categoryList.Select(categoryDto => new CategoryDto()
            {
                Name = categoryDto.CategoryName,
                Description = categoryDto.Description,
                CreatedDate = categoryDto.CreatedDate,
                UpdatedDate = categoryDto.UpdatedDate
            });
            return result.ToList();
        }
    }
}
