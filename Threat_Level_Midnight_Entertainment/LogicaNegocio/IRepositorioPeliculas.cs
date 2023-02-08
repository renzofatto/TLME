using Dominio;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public interface IRepositorioPeliculas
    {
        void Agregar(Pelicula unaPelicula);
        LogicaNegocioPelicula Clonar();
        void Eliminar(Pelicula unaPelicula);
        List<Pelicula> ObtenerPeliculas();
    }
}