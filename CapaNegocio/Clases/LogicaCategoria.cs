using CapaDatos;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Clases
{
    public class LogicaCategoria : ICategoria
    {
        private readonly TareasContext db;
        public LogicaCategoria(TareasContext db)
        {
            this.db = db;
        }
        public List<Categorium> GetCategorias()
        {
            return db.Categoria.ToList();
        }
        public void AddCategoria(Categorium categoria)
        {
            db.Categoria.Add(categoria);
            db.SaveChanges();
        }
        public void UpdateCategoria(Categorium categoria)
        {
            var categoriaExistente = db.Categoria.Find(categoria.IdCategoria);
            if (categoriaExistente != null)
            {
                categoriaExistente.NombreCategoria = categoria.NombreCategoria;
                categoriaExistente.FechaActualizacion = DateTime.UtcNow; // Se actualiza la fecha
                db.Categoria.Update(categoriaExistente);
                db.SaveChanges();
            }
        }
    }
    
}
