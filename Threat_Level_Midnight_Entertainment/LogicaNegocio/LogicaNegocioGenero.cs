using Dominio;
using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class LogicaNegocioGenero
    {

        private readonly IRepositorioGeneros _repositorioGeneros;

        public LogicaNegocioGenero(IRepositorioGeneros repositorioGeneros)
        {
            this._repositorioGeneros = repositorioGeneros;
        }
        
        public void Agregar(Genero unGenero)
        {
            foreach (Genero genero in _repositorioGeneros.ObtenerGeneros())
            {
                if (genero.Nombre.Equals(unGenero.Nombre))
                {
                    throw new LogicaNegocioGeneroExcepcion("El genero ya esta ingresado en el sistema.");
                }

            }
            _repositorioGeneros.Agregar(unGenero);
            
        }

        public LogicaNegocioGenero Clonar()
        {
            return _repositorioGeneros.Clonar();
        }

        public void Eliminar(Genero genero)
        {
            if (genero.Peliculas.Count==0)
            {
                _repositorioGeneros.Eliminar(genero);
            }
            else
            {
                throw new LogicaNegocioGeneroExcepcion("No se puede eliminar un genero que tiene peliculas asociadas");
            }
            
        }

        public Genero ObtenerGeneroPorNombre(string nombreABuscar)
        {
            foreach (Genero genero in _repositorioGeneros.ObtenerGeneros())
            {
                if (genero.Nombre.Equals(nombreABuscar))
                {
                    return genero;
                }
            }
            throw new LogicaNegocioGeneroExcepcion("El genero no esta ingresado en el sistema.");
        }

        public List<Genero> ObtenerGeneros()
        {
            return _repositorioGeneros.ObtenerGeneros();
        }
    }
}