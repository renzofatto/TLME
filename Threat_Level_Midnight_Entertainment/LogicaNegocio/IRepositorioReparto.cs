using System.Collections.Generic;
using Dominio;

namespace LogicaNegocio
{
    public interface IRepositorioReparto
    {
        void Agregar(Reparto reparto);
        void Eliminar(Reparto reparto);
        List<Actor> ObtenerActores();
        List<Director> ObtenerDirectores();
        List<Reparto> ObtenerRepartos();
    }
}