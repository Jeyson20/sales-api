using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryName)
                       .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                       .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.Description)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                  .MaximumLength(60).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
