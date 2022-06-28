using FluentValidation;
using ShoppingList.Application.Commands.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation()
        {
            RuleFor(r => r.Name)
                .MinimumLength(2)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(r => r.Description)
                .MinimumLength(5)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(r => r.CreatedDate)
                .NotEmpty();
            RuleFor(r => r.UpdatedDate)
                .NotEmpty();
        }
    }
}
