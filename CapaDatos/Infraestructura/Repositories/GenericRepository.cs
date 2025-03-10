using CapaDatos;
using CapaDatos.DTO;
using CapaDatos.DTO.TareaDTO;
using CapaDatos.DTO.UsuarioDTO;
using CapaDatos.Infraestructura;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TareasApi.Infraestructura.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TareasContext _context;
        public GenericRepository(TareasContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null ? _context.Set<TEntity>() : _context.Set<TEntity>().Where(filter);
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }
        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task Add(UsuarioDTO newUsuario)
        {
            var usuario = new Usuario
            {
                // Map properties from newUsuario to usuario
                Nombre = newUsuario.Nombre,
                Apellido = newUsuario.Apellido,
                Sexo = newUsuario.Sexo,
                FechaCreacion = DateTime.UtcNow, // Asigna la fecha de creación
            };
            await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task Update(UpdateUsuarioDTO usuarioDto)
        {
            var usuario = await _context.Set<Usuario>().FindAsync(usuarioDto.IdUsuario);
            if (usuario != null)
            {
                // Map properties from usuarioDto to usuario
                usuario.Nombre = usuarioDto.Nombre;
                usuario.Apellido = usuarioDto.Apellido;
                usuario.Sexo = usuarioDto.Sexo;
                usuario.FechaActualizacion = DateTime.UtcNow; // Asigna la fecha de actualización
                _context.Set<Usuario>().Update(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Add(TareaDTO newTareaDTO)
        {
            var tarea = new Tarea
            {
                Descripcion = newTareaDTO.Descripcion,
                EstadoTarea = newTareaDTO.EstadoTarea,
                IdCategoria = newTareaDTO.IdCategoria,
                IdUsuario = newTareaDTO.IdUsuario,
                FechaCreacion = DateTime.UtcNow, // Asigna la fecha de creación
            };

            await _context.Set<Tarea>().AddAsync(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UpdateTareaDTO updateTareaDto)
        {

            var tarea = await _context.Set<Tarea>().FindAsync(updateTareaDto.IdTarea);
            if (tarea != null)
            {
                // Map properties from usuarioDto to usuario
                tarea.Descripcion = updateTareaDto.Descripcion;
                tarea.EstadoTarea = updateTareaDto.EstadoTarea;
                tarea.IdCategoria = updateTareaDto.IdCategoria;
                tarea.IdUsuario = updateTareaDto.IdUsuario;
                tarea.FechaActualizacion = DateTime.UtcNow;
                _context.Set<Tarea>().Update(tarea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
