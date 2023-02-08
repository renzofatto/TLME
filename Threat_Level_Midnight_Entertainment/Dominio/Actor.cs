using System.Collections.Generic;

namespace Dominio
{
    public class Actor : Reparto
    {
        private List<Pelicula> peliculasActuadas = new List<Pelicula>();

        public List<Pelicula> PeliculasActuadas
        {
            get => peliculasActuadas;
            set => peliculasActuadas = value;
        }
        public void AgregarPeliculaActuada(Pelicula pelicula)
        {
            PeliculasActuadas.Add(pelicula);
        }
    }
}