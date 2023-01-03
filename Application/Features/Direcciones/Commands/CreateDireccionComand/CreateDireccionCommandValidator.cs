using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Commands.CreateDireccionComand
{
    public class CreateDireccionCommandValidator : AbstractValidator<CreateDireccionCommand>
    {
        public CreateDireccionCommandValidator()
        {
            RuleFor(p => p.Alias)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .MaximumLength(25).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.CalleNumero)
                .NotEmpty().WithMessage("Calle y Númnero no puede ser vacío")
                .MaximumLength(250).WithMessage("Calle y Númnero no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Colonia)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.CodigoPostal)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío");

            RuleFor(p => p.Ciudad)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Estado)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Pais)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

        }
    }
}
