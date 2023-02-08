using Dominio;
using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class LogicaNegocioReparto
    {
        private readonly IRepositorioReparto _repositorioReparto;

        public LogicaNegocioReparto(IRepositorioReparto repositorioReparto)
        {
            this._repositorioReparto = repositorioReparto;
        }

        public void Agregar(Reparto reparto)
        {
            this._repositorioReparto.Agregar(reparto);
        }

        public void Eliminar(Reparto reparto)
        {
            this._repositorioReparto.Eliminar(reparto);
        }

        public List<Reparto> ObtenerRepartos()
        { 
            return this._repositorioReparto.ObtenerRepartos();
        }
        public List<Director> ObtenerDirectores()
        { 
            return this._repositorioReparto.ObtenerDirectores();
        }
        public List<Actor> ObtenerActores()
        { 
            return this._repositorioReparto.ObtenerActores();
        }
    }
}