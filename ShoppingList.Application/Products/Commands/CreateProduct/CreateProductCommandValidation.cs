using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(r => r.Name)
                .MinimumLength(2)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(r => r.Price)
                .GreaterThan(0).NotEmpty();
            RuleFor(r => r.Feature)
                .MinimumLength(5)
                .MaximumLength(100)
                .NotEmpty();
            RuleFor(r => r.CategoryId)
                .NotEmpty();
        }
    }
}
