﻿using CapaDatos.DTO.TareaDTO;
using CapaDatos.DTO.UsuarioDTO;
using CapaDatos.Modelos;
using CapaNegocio.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TareasApi.Infraestructura.Repositories;


namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TareasController : ControllerBase
    {
        private readonly IGenericRepository<Tarea> _repository;
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<Categorium> _categoriaRepository;

        ITarea _tarea;
        private readonly IUsuarios _usuarios;
        private readonly ICategoria _categorias; // Añadir esta línea

        public TareasController(IGenericRepository<Tarea> repository,
        IGenericRepository<Usuario> usuarioRepository,
        IGenericRepository<Categorium> categoriaRepository) // Modificar esta línea
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _categoriaRepository = categoriaRepository;
            //_tarea = tarea;
            //_usuarios = usuarios; // Añadir esta línea
            //_categorias = categorias; // Añadir esta línea
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            var tarea = await _repository.GetAll();
            return Ok(tarea.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTareasById(int id)
        {
            var tarea = await _repository.Get(u => u.IdTarea == id);
            if (tarea is null)
                return NotFound();

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult<Tarea>> AddTareas(TareaDTO newTareaDTO)
        {
            await _repository.Add(newTareaDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tarea>> UpdateTarea(int id, UpdateTareaDTO updateTareaDto)
        {

            await _repository.Update(updateTareaDto);
            return Ok();

        }

        [HttpGet("usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAll();  // Método en LogicaUsuarios que devuelve todos los usuarios
            return Ok(usuarios.ToList());
        }

        [HttpGet("categorias")]
        public async Task<ActionResult<IEnumerable<Categorium>>> GetCategorias()
        {
            var categorias = await _categoriaRepository.GetAll();  // Método en LogicaCategorias que devuelve todas las categorías
            return Ok(categorias.ToList());
        }
    }
}



//using FluentValidation;
//using MediatR;
//using ErrorOr;

//namespace TareasApi.Validacion.Behaviors
//{
//    public class ValidationBehavior<TResquest, TResponse> : IPipelineBehavior<TResquest, TResponse>
//        where TResquest : IRequest<TResponse>
//        where TResponse : IErrorOr
//    {
//        private readonly IValidator<TResquest>? _validator;
//        public ValidationBehavior(IValidator<TResquest>? validator = null)
//        {
//            _validator = validator;
//        }
//        public async Task<TResponse> Handle(
//            TResquest request, CancellationToken cancellationToken,
//            RequestHandlerDelegate<TResponse> next)
//        {
//            if (_validator is null)
//            {
//                return await next();
//            }


//            var validationResults = await _validator.ValidateAsync(request, cancellationToken);
//            if (validationResults.IsValid)
//                return await next();

//            var errors = validationResults.Errors.Select(e => e.ErrorMessage);
//        }

//        public Task<TResponse> Handle(TResquest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
