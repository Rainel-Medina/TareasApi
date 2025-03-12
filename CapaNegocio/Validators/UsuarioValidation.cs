using CapaDatos.DTO.UsuarioDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Validators
{
    class UsuarioValidation : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidation() 
        {
            RuleFor(u => u.Nombre)
                .NotEmpty().WithMessage("El nombre del usuario no puede estar vacío")
                .MaximumLength(50).WithMessage("El nombre del usuario no puede tener más de 50 caracteres");

           RuleFor(u => u.Apellido)
                .NotEmpty().WithMessage("El apellido del usuario no puede estar vacío")
                .MaximumLength(50).WithMessage("El apellido del usuario no puede tener más de 50 caracteres");

            RuleFor(u => u.Sexo)
                .Must(s => s == 0 || s == 1).WithMessage("El sexo del usuario debe ser (Masculino) (Femenino)");
        }
    }
}
