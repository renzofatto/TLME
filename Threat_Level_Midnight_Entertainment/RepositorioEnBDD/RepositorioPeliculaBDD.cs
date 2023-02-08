using Dominio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using RepositorioEnBDD;

namespace RepositorioEnBDD
{
    public class RepositorioPeliculasBDD : IRepositorioPeliculas
    {
        public void Agregar(Pelicula unaPelicula)
        {
            using (var context = new TLMDBContext())
            {
                context.Peliculas.Add(unaPelicula);
                context.SaveChanges();
            }
        }

        public LogicaNegocioPelicula Clonar()
        {
            IRepositorioPeliculas repositorioPeliculas = new RepositorioPeliculasBDD();
            LogicaNegocioPelicula logicaPeliculaClon = new LogicaNegocioPelicula(repositorioPeliculas);
            using (var context = new TLMDBContext())
            {
                foreach (Pelicula pelicula in this.ObtenerPeliculas())
                {
                    logicaPeliculaClon.Agregar(pelicula.Clon());
                }
            }
            return logicaPeliculaClon;
        }

        public void Eliminar(Pelicula unaPelicula)
        {
            Pelicula pelicula = ObtenerPeliculaPorID(unaPelicula.Id);

            using (var context = new TLMDBContext())
            {
                context.Peliculas.Remove(pelicula);
                context.SaveChanges();
            }
        }

        private Pelicula ObtenerPeliculaPorID(object id)
        {
            throw new NotImplementedException();
        }

        public Pelicula ObtenerPeliculaPorID(int id)
        {
            using (var context = new TLMDBContext())
            {
                return context.Peliculas.Where(c => c.Id == id).Include(c => c.Actores)
                                                               .Include(c => c.Actuaciones)
                                                               .Include(c => c.Directores)
                                                               .Include(c => c.GeneroPrincipal)
                                                               .Include(c => c.GeneroSecundario).FirstOrDefault();
            }
        }

        public List<Pelicula> ObtenerPeliculas()
        {
            using (var context = new TLMDBContext())
            {
                return context.Peliculas.Include(c => c.Actores)
                                        .Include(c => c.Actuaciones)
                                        .Include(c => c.Directores)
                                        .Include(c => c.GeneroPrincipal)
                                        .Include(c => c.GeneroSecundario).ToList();
            }
        }
    }
}using Dominio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioBDD
{
    public class RepositorioPeliculasBDD : IRepositorioPeliculas
    {
        public void Agregar(Pelicula unaPelicula)
        {
            using (var context = new TLMDBContext())
            {
                context.Peliculas.Add(unaPelicula);
                context.SaveChanges();
            }
        }

        public LogicaNegocioPelicula Clonar()
        {
            IRepositorioPeliculas repositorioPeliculas = new RepositorioPeliculasBDD();
            LogicaNegocioPelicula logicaPeliculaClon = new LogicaNegocioPelicula(repositorioPeliculas);
            using (var context = new TLMDBContext())
            {
                foreach (Pelicula pelicula in this.ObtenerPeliculas())
                {
                    logicaPeliculaClon.Agregar(pelicula.Clon());
                }
            }
            return logicaPeliculaClon;
        }

        public void Eliminar(Pelicula unaPelicula)
        {
            Pelicula pelicula = ObtenerPeliculaPorID(unaPelicula.Id);

            using (var context = new TLMDBContext())
            {
                context.Peliculas.Remove(pelicula);
                context.SaveChanges();
            }
        }

        public Pelicula ObtenerPeliculaPorID(int id)
        {
            using (var context = new TLMDBContext())
            {
                return context.Peliculas.Where(c => c.Id == id).Include(c => c.Actores)
                                                               .Include(c => c.Actuaciones)
                                                               .Include(c => c.Directores)
                                                               .Include(c => c.GeneroPrincipal)
                                                               .Include(c => c.GeneroSecundario).FirstOrDefault();
            }
        }

        public List<Pelicula> ObtenerPeliculas()
        {
            using (var context = new TLMDBContext())
            {
                return context.Peliculas.Include(c => c.Actores)
                                        .Include(c => c.Actuaciones)
                                        .Include(c => c.Directores)
                                        .Include(c => c.GeneroPrincipal)
                                        .Include(c => c.GeneroSecundario).ToList();
            }
        }
    }
}