using CapaDatos.DTO.CategoriaDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Validators
{
    public class CategoriaValidation : AbstractValidator<CategoriaDTO>
    {
        public CategoriaValidation()
        {
            RuleFor(c => c.NombreCategoria)
                .NotEmpty().WithMessage("El nombre de la categoría no puede estar vacío")
                .MaximumLength(50).WithMessage("El nombre de la categoría no puede tener más de 50 caracteres");
        }

    }
}
