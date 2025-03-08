using Microsoft.EntityFrameworkCore;

namespace TareasApi.Data
{
    public class TareasDbContext(DbContextOptions<TareasDbContext> options) : DbContext(options)
    {
        public DbSet<Tarea> Tarea => Set<Tarea>();

        public DbSet<Categoria> Categoria => Set<Categoria>();

        public DbSet<Usuarios> Usuarios => Set<Usuarios>();

    }
}
