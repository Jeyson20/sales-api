using FluentValidation;

namespace Sample.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
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
