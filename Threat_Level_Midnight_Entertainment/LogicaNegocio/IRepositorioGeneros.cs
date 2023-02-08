using Dominio;
using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public interface IRepositorioGeneros
    {
        void Agregar(Genero unGenero);
        LogicaNegocioGenero Clonar();
        void Eliminar(Genero genero);
        List<Genero> ObtenerGeneros();
    }
}