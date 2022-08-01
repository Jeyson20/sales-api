using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.FirstName)
                       .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(x => x.LastName)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
            .MaximumLength(13).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.Address)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(x => x.CityId)
                      .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(x => x.Email)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                  .EmailAddress().WithMessage("Formato de email no valido");

            RuleFor(x => x.PhoneNumber)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
             .MaximumLength(12).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}