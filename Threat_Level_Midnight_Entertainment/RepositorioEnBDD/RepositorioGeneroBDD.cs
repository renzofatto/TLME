using Dominio;
using LogicaNegocio;
using RepositorioEnBDD;
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
            IRepositorioGeneros repositorioGenero = new RepositorioGenerosBDD();
            LogicaNegocioGenero logicaGeneroClon = new LogicaNegocioGenero(repositorioGenero);
            using (var context = new TLMDBContext())
            {
                foreach (Genero genero in this.ObtenerGeneros())
                {
                    logicaGeneroClon.Agregar(genero.Clon());
                }
            }
            return logicaGeneroClon;
        }

        public void Eliminar(Genero genero)
        {
            Genero unGenero = ObtenerGenerosPorID(genero.Id);
            using (var context = new TLMDBContext())
            {
                context.Generos.Remove(unGenero);
                context.SaveChanges();
            }
        }

        public Genero ObtenerGenerosPorID(int id)
        {
            using (var context = new TLMDBContext())
            {
                return context.Generos.Where(c => c.Id == id).Include(c => c.Peliculas).FirstOrDefault();

            }
        }


        public List<Genero> ObtenerGeneros()
        {
            using (var context = new TLMDBContext())
            {
                return context.Generos.Include(c => c.Peliculas).ToList();
            }
        }
    }
}