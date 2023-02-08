using Dominio;
using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class LogicaNegocioPelicula
    {
        private readonly IRepositorioPeliculas _repositorioPeliculas;
        public LogicaNegocioPelicula(IRepositorioPeliculas repositorioPeliculas)
        {
            this._repositorioPeliculas = repositorioPeliculas;
        }

        public void Agregar(Pelicula unaPelicula)
        {
            foreach (Pelicula pelicula in _repositorioPeliculas.ObtenerPeliculas())
            {
                if (pelicula.Nombre.Equals(unaPelicula.Nombre))
                {
                    throw new LogicaNegocioPeliculaExcepcion("La pelicula ya esta ingresada en el sistema.");
                }
            }
            if (unaPelicula.ValidarNombre())
            {
                _repositorioPeliculas.Agregar(unaPelicula);
            }
        }

        public LogicaNegocioPelicula Clonar()
        {
            return _repositorioPeliculas.Clonar();
        }

        public void Eliminar(Pelicula unaPelicula)
        {
            _repositorioPeliculas.Eliminar(unaPelicula);
        }

        public List<Pelicula> ObtenerPelicula()
        {
           return _repositorioPeliculas.ObtenerPeliculas();
        }

        public Pelicula ObtenerPeliculaPorNombre(string v)
        {
            foreach (Pelicula pelicula in _repositorioPeliculas.ObtenerPeliculas())
            {
                if (pelicula.Nombre.Equals(v))
                {
                    return pelicula;
                }
            }
            throw new LogicaNegocioPeliculaExcepcion("La pelicula no esta ingresada en el sistema.");
        }
    }
}