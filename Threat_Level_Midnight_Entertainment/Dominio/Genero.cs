using Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio
{
    public class Genero
    {
        private const int puntajeInicial = 0;
        private int _puntaje = puntajeInicial;
        private string _nombre;
        private List<Pelicula> _peliculas = new List<Pelicula>();
        public int Id { get; set; }
        private string _descripcion= "Sin descripcion";
        
        public string Nombre
        {
            get=> _nombre;
            set
            {
                if (value.Equals(""))
                {
                    throw new GeneroInvalidoExcepcion("El nombre del genero no puede ser vacío.");
                }
                else
                {
                    _nombre = value;
                }
            }
        }

        public string Descripcion 
        { 
            get => _descripcion;
            set => _descripcion = value;
        }

        public List<Pelicula> Peliculas
        {
            get => _peliculas; 
            set=> _peliculas = value;
        }
       
        public int Puntaje 
        { 
            get => _puntaje; 
            set => _puntaje = value; 
        }

        public void AgregarPelicula(Pelicula unaPelicula)
        {
            _peliculas.Add(unaPelicula);
        }

        public Genero Clon()
        {
            Genero generoClon = new Genero
            {
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
                Puntaje = puntajeInicial
            };
            foreach (Pelicula pelicula in this.Peliculas)
            {
                generoClon.Peliculas.Add(pelicula.Clon());
            }
            return generoClon;
        }

        public override string ToString()
        {
            return $"{this.Nombre}";
        }
    }
}