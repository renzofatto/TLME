using System;
using Dominio;
using LogicaNegocio;
using System.Collections.Generic;

namespace RepositorioEnMemoria
{
    public class RepositorioRepartoImpl : IRepositorioReparto
    {
        private List<Reparto> Reparto { get; }
        public RepositorioRepartoImpl()
        {
            Reparto = new List<Reparto>();
        }
        public void Agregar(Reparto reparto)
        {
            Reparto.Add(reparto);
        }

        public List<Reparto> ObtenerRepartos()
        {
            return Reparto;
        }

        public void Eliminar(Reparto reparto)
        {
            Reparto.Remove(reparto);
        }

        public List<Director> ObtenerDirectores()
        {
            List<Director> directores = new List<Director>();
            foreach (Reparto reparto in Reparto)
            {
                if (reparto.GetType()== typeof(Director))
                {
                    directores.Add((Director)reparto);
                }
            }

            return directores;
        }
        public List<Actor> ObtenerActores()
        {
            List<Actor> actores = new List<Actor>();
            foreach (Reparto reparto in Reparto)
            {
                if (reparto.GetType()== typeof(Actor))
                {
                    actores.Add((Actor)reparto);
                }
            }

            return actores;
        }
    }
}