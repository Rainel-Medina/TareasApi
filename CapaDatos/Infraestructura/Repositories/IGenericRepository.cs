using CapaDatos.DTO.UsuarioDTO;
using System.Linq.Expressions;

namespace TareasApi.Infraestructura.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //void Add(TEntity entity);
        //void Update(TEntity entity);
        //void Delete(TEntity entity);
        //IEnumerable<TEntity> GetAll();
        //TEntity GetById(int id);

        Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetById(int id);
        Task<TEntity> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task Add(UsuarioDTO newUsuario);
        //Task Update(UsuarioDTO usuarioDto);
        Task Update(UpdateUsuarioDTO usuarioDto);
    }
}
