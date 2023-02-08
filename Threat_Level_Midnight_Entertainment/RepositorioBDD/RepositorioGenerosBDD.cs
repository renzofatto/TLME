using Dominio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioBDD
{
    public class RepositorioGenerosBDD : IRepositorioGeneros
    {
        public void Agregar(Genero unGenero)
        {
            using (var context = new TLMDBContext())
            {
                context.Generos.Add(unGenero);
                context.SaveChanges();
            }
        }

        public LogicaNegocioGenero Clonar()
        {
            return null;
            //   throw new NotImplementedException();
        }

        public Genero ObtenerPorId(int Id)
        {

            using (var context = new TLMDBContext())
            {
                return context.Generos.Where(c => c.Id == Id).Include(c => c.Nombre).Include(c => c.Descripcion).FirstOrDefault();
            }
        }

        public void Eliminar(Genero genero)
        {
            Genero unGenero = null;
            //Genero unGenero = ObtenerPorId(genero.Id);

            using (var context = new TLMDBContext())
            {
                context.Generos.Remove(unGenero);
                context.SaveChanges();
            }
        }

        public List<Genero> ObtenerGeneros()
        {
            using (var context = new TLMDBContext())
            {
                return context.Generos.ToList();
            }
        }
    }
}
