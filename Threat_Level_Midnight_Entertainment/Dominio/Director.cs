using System.Collections.Generic;

namespace Dominio
{
    public class Director : Reparto
    {
        private List<Pelicula> _peliculasDirigidas = new List<Pelicula>();

        public List<Pelicula> PeliculasDirigidas
        {
            get => _peliculasDirigidas;
            set => _peliculasDirigidas = value;
        }
        public void AgregarPeliculaDirigida(Pelicula pelicula)
        {
            PeliculasDirigidas.Add(pelicula);
        }
    }
}