using Dominio;
using LogicaNegocio;
using System.Collections.Generic;

namespace RepositorioEnMemoria
{
    public class RepositorioGenerosImpl : IRepositorioGeneros
    {
        private List<Genero> Generos { get; }

        public RepositorioGenerosImpl()
        {
            Generos = new List<Genero>();
        }

        public void Agregar(Genero unGenero)
        {
            Generos.Add(unGenero);
        }
        
        public void Eliminar(Genero unGenero)
        {
            Generos.Remove(unGenero);
        }

        public List<Genero> ObtenerGeneros()
        {
            return Generos;
        }

        public LogicaNegocioGenero Clonar()
        {
            IRepositorioGeneros repositorioGeneros = new RepositorioGenerosImpl();
            LogicaNegocioGenero logicaGeneroClon = new LogicaNegocioGenero(repositorioGeneros);
            foreach (Genero genero in this.ObtenerGeneros())
            {
                logicaGeneroClon.Agregar(genero.Clon());
            }
            return logicaGeneroClon; ;
        }
    }
}