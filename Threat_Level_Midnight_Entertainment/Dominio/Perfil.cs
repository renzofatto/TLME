using Dominio.Excepciones;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Perfil
    {
        private const int maximoCaracteres = 15; 
        private const int largoPin = 5; 
        private bool _infantil = false;
        private List<Genero> _generos = new List<Genero>();
        private List<Pelicula> _peliculas = new List<Pelicula>();
        private List<Pelicula> _peliculasVistas = new List<Pelicula>();
        public int Id { get; set; }
        public string Alias { get; set; }
        public int Pin { get; set; }
        public bool Owner { get; set; }
        public bool Infantil 
        { 
            get => _infantil;
            set {
                if (this.Owner && value == true)
                {
                    throw new PerfilInvalidoExcepcion("El perfil no puede ser Infantil ya que es Owner.");
                }
                else
                {
                    _infantil = value;
                }
            }
        }

        public bool Logged { get; set; }

        public List<Genero> Generos
        {
            get => _generos; 
            set => _generos=value;
        }
        public List<Pelicula> Peliculas
        {
            get => _peliculas;
            set => _peliculas = value;
        }

        public List<Pelicula> PeliculasVistas
        {
            get => _peliculasVistas; 
            set => _peliculasVistas = value;
        }

        public bool CoincidePin(int unPin)
        {
            return unPin==this.Pin;
        }

        public bool ValidarAlias()
        {
            if (this.Alias.Equals(""))
            {
                throw new PerfilInvalidoExcepcion("El alias no puede tener menos de 1 caracter.");
            }
            if (this.Alias.Length > maximoCaracteres)
            {
                throw new PerfilInvalidoExcepcion($"El alias no puede tener mas de {maximoCaracteres} caracteres.");
            }
            if (Alias.Contains("0")|| Alias.Contains("1") || Alias.Contains("2") || Alias.Contains("3") || Alias.Contains("4") || Alias.Contains("5") || Alias.Contains("6") ||
                Alias.Contains("7") || Alias.Contains("8") || Alias.Contains("9"))
            {
                throw new PerfilInvalidoExcepcion("El alias no puede tener ningun numero en el nombre.");
            }
            return true;
        }

        public bool ValidarPin(string pin)
        {
            if (pin.Length == largoPin) 
            {
                try
                {
                    int pinNumerico = Int32.Parse(pin);
                }
                catch (Exception ex)
                {
                    throw new PerfilInvalidoExcepcion("El pin debe ser numerico.");
                }
            }
            else if (pin.Length < largoPin)
            {
                throw new PerfilInvalidoExcepcion($"El pin no puede tener menos de {largoPin} digitos.");
            }
            else
            {
                throw new PerfilInvalidoExcepcion($"El pin no puede tener mas de {largoPin} digitos.");
            }
            return true;
        }
        public override string ToString()
        {
            return $"{this.Alias}";
        }

        public void AgregarGenero(Genero unGenero)
        {
            Generos.Add(unGenero);
        }

        public void AgregarPelicula(Pelicula unaPelicula)
        {
            Peliculas.Add(unaPelicula);
        }

        public void ClonarGeneros(List<Genero> logicaGenero)
        {
            foreach (Genero genero in logicaGenero)
            {
                this.AgregarGenero(genero.Clon());
            }
        }

        public void ClonarPeliculas(List<Pelicula> logicaPelicula)
        {
            foreach (Pelicula pelicula in logicaPelicula)
            {
                this.AgregarPelicula(pelicula.Clon());
            }
        }

        public void AgregarPeliculaClonada(Pelicula unaPelicula)
        {
            this.Peliculas.Add(unaPelicula.Clon());
        }

        public void AgregarGeneroClonado(Genero unGenero)
        {
            this.Generos.Add(unGenero.Clon());
        }

        public void AgregarPeliculaVista(Pelicula unaPelicula)
        {
            this.PeliculasVistas.Add(unaPelicula.Clon());
        }
    }
}