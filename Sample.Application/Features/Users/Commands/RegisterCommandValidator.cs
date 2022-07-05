using FluentValidation;

namespace Sample.Application.Features.Users.Commands
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {

            RuleFor(x => x.FirstName)
                       .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                       .MaximumLength(60).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.LastName)
                      .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                      .MaximumLength(60).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                 .EmailAddress().WithMessage("{PropertyName} debe ser una direccion de email valida")
                 .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.Rol.ToString())
                   .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                 .MinimumLength(8).WithMessage("{PropertyName} no debe exceder de {MinLength} caracteres");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MinimumLength(8).WithMessage("{PropertyName} no debe exceder de {MinLength} caracteres")
                .Equal(p => p.Password).WithMessage("Las contraseñas deben ser iguales");
        }
    }
}
