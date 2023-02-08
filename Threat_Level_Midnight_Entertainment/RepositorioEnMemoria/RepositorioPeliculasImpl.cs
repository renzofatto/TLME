using Dominio;
using LogicaNegocio;
using System.Collections.Generic;

namespace RepositorioEnMemoria
{
    public class RepositorioPeliculasImpl : IRepositorioPeliculas
    {
        private List<Pelicula> Peliculas{ get; }

        public RepositorioPeliculasImpl()
        {
            Peliculas = new List<Pelicula>();
        }

        public void Agregar(Pelicula pelicula)
        {
            Peliculas.Add(pelicula);
        }

        public List<Pelicula> ObtenerPeliculas()
        {
            return Peliculas;
        }

        public void Eliminar(Pelicula unaPelicula)
        {
            Peliculas.Remove(unaPelicula);
        }

        public LogicaNegocioPelicula Clonar()
        {
            IRepositorioPeliculas repositorioPeliculas = new RepositorioPeliculasImpl();
            LogicaNegocioPelicula logicaPeliculaClon = new LogicaNegocioPelicula(repositorioPeliculas);
            foreach (Pelicula pelicula in this.ObtenerPeliculas())
            {
                logicaPeliculaClon.Agregar(pelicula.Clon());
            }
            return logicaPeliculaClon;
        }
    }
}