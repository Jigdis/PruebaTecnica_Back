using Application.Features.Direcciones.Commands.CreateDireccionComand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Commands.DeleteDireccionCommand
{
    public class DeleteDireccionCommandValidator : AbstractValidator<DeleteDireccionCommand>
    {
        public DeleteDireccionCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío");
        }
    }
}
