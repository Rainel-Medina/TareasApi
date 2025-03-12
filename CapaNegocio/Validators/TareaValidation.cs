using CapaDatos.DTO.TareaDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Validators
{
    class TareaValidation : AbstractValidator<TareaDTO>
    {
        public TareaValidation(List<int> categoriasValidas, List<int> usuariosValidos)
        {
            RuleFor(c => c.Descripcion)
                .NotEmpty().WithMessage("El nombre de la tarea no puede estar vacío")
                .MaximumLength(250).WithMessage("El nombre de la tarea no puede tener más de 250 caracteres");

            RuleFor(c => c.EstadoTarea)
                .Must(e => e == 0 || e == 1)
                .WithMessage("El estado de la tarea debe ser (Inactivo) (Activo)");

            RuleFor(c => c.IdCategoria)
                .Must(id => categoriasValidas.Contains(id))
                .WithMessage("La categoría no es válido");

            RuleFor(c => c.IdUsuario)
                .Must(id => usuariosValidos.Contains(id))
                .WithMessage("El usuario no es válido");
        }
    }
}
