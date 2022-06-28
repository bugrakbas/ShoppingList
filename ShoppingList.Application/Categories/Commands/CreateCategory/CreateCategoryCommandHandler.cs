using MediatR;
using ShoppingList.Application.Common.Interfaces.Repositories;
using ShoppingList.Application.Commands.CreateCategory;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                CategoryName = request.Name,
                Description = request.Description,
                CreatedDate = request.CreatedDate,
                UpdatedDate = request.UpdatedDate
            };
            await _categoryRepository.Add(category);
            return category;
        }
    }
}
