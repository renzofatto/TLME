using Dominio.Excepciones;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Pelicula
    {
        private const string descripcionPorDefecto = "Sin descripcion";
        private string _descripcion = descripcionPorDefecto;
        private List<Genero> _generoSecundario = new List<Genero>();
        private List<Reparto> _directores= new List<Reparto>();
        private List<Reparto> _actores= new List<Reparto>();
        private List<Actuacion> _actuaciones= new List<Actuacion>();
        public string Nombre { get; set; }
        public bool Patrocinada { get; set; }
        public string Descripcion
        {
            get => _descripcion; 
            set => _descripcion = value;
        }
        public bool ATP { get; set; }
        public int Calificacion { get; set; }
        public int Reproducciones { get; set; }
        public int Puntaje { get; set; }
        public Genero GeneroPrincipal { get; set; }

        public List<Genero> GeneroSecundario
        {
            get => _generoSecundario; 
            set => _generoSecundario = value;
        }
        public bool Vista { get; set; }
        public string Imagen { get; set; }

        public List<Reparto> Directores
        {
            get=> _directores; 
            set=> _directores = value;
        }

        public List<Reparto> Actores
        {
            get=> _actores; 
            set=> _actores = value;
        }

        public List<Actuacion> Actuaciones
        {
            get=>_actuaciones; 
            set=>_actuaciones = value;
        }
        public DateTime Estreno { get; set; }
        public int Id { get; set; }

        public void AgregarGeneroSecundario(Genero genero)
        {
            this._generoSecundario.Add(genero);
        }

        public void CalificacionMuyPositiva()
        {
            if (this.Calificacion != 0)
            {
                int calificacionAnterior = 0 + this.Calificacion;
                if (calificacionAnterior > 0)
                {
                    this.GeneroPrincipal.Puntaje -= calificacionAnterior;
                    this.Calificacion -= calificacionAnterior;
                    this.Puntaje -= calificacionAnterior;
                }
                else
                {
                    this.GeneroPrincipal.Puntaje++;
                    this.Calificacion++;
                    this.Puntaje++;
                }

                if (calificacionAnterior == 2 )
                {
                    foreach (Genero genero in this.GeneroSecundario)
                    {
                        genero.Puntaje--;
                    }
                }
            }
            this.Calificacion+=2;
            this.Puntaje += 2;
            this.GeneroPrincipal.Puntaje +=2;
            foreach (Genero genero in this.GeneroSecundario)
            {
                genero.Puntaje++;
            }
            
        }

        public void CalificacionNegativa()
        {
            if (this.Calificacion != 0)
            {
                int calificacionAnterior = 0+this.Calificacion;
                if (calificacionAnterior>0)
                {
                    this.GeneroPrincipal.Puntaje -= calificacionAnterior;
                    this.Calificacion -= calificacionAnterior;
                    this.Puntaje -= calificacionAnterior;
                }
                else
                {
                    this.GeneroPrincipal.Puntaje += calificacionAnterior;
                    this.Calificacion -= calificacionAnterior;
                    this.Puntaje -= calificacionAnterior;
                }

                if (calificacionAnterior == 2)
                {
                    foreach (Genero genero in this.GeneroSecundario)
                    {
                        genero.Puntaje--;
                    }
                }
            }
            this.Calificacion--;
            this.Puntaje--;
            this.GeneroPrincipal.Puntaje--;
            if (this.Vista)
            {
                this.Calificacion++;
                this.Puntaje++;
                this.GeneroPrincipal.Puntaje++;
            }
        }

        public void CalificacionPositiva()
        {
            if (this.Calificacion != 0)
            {
                int calificacionAnterior = 0 + this.Calificacion;
                if (calificacionAnterior > 0)
                {
                    this.GeneroPrincipal.Puntaje -= calificacionAnterior;
                    this.Calificacion -= calificacionAnterior;
                    this.Puntaje -= calificacionAnterior;
                }
                else
                {
                    this.GeneroPrincipal.Puntaje += calificacionAnterior;
                    this.Calificacion -= calificacionAnterior;
                    this.Puntaje -= calificacionAnterior;
                }

                if (calificacionAnterior == 2)
                {
                    foreach (Genero genero in this.GeneroSecundario)
                    {
                        genero.Puntaje--;
                    }
                }
            }
            this.Calificacion++;
            this.Puntaje++;
            this.GeneroPrincipal.Puntaje++;
            
        }

        public void Reproducirse()
        {
            this.Reproducciones++;
            this.Puntaje++;
        }

        public bool ValidarNombre()
        {
            if (this.Nombre.Equals(""))
            {
                throw new PeliculaInvalidaExcepcion("El nombre de la pelicula no puede ser vacío.");
            }
            return true;
        }

        public void Visualizar()
        {
            if (!this.Vista)
            {
                this.Vista = true;
                this.GeneroPrincipal.Puntaje++;
                this.Puntaje++;
            }
        }

        public override string ToString()
        {
            return $"{this.Nombre}";
        }

        public Pelicula Clon()
        {
            Pelicula peliculaClon = new Pelicula
            {
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
                ATP = this.ATP,
                Calificacion = 0,
                Reproducciones = 0,
                Puntaje = 0,
                GeneroPrincipal = this.GeneroPrincipal,
                GeneroSecundario = this.GeneroSecundario,
                Vista = false,
                Imagen = this.Imagen,
                Directores = this.Directores,
                Actores = this.Actores,
                Actuaciones = this.Actuaciones,
                Estreno = this.Estreno,
                Patrocinada = this.Patrocinada,

            };

            /*if (this.GeneroPrincipal!=null)
            {
                peliculaClon.GeneroPrincipal = this.GeneroPrincipal;
            }
            else
            {
                peliculaClon.GeneroPrincipal = null;
            }

            if (peliculaClon.GeneroSecundario != null)
            {
                foreach (Genero genero in this.GeneroSecundario)
                {
                    peliculaClon.GeneroSecundario.Add(genero.Clon());
                }
            }
            else
            {
                peliculaClon.GeneroSecundario = null;
            }*/
            return peliculaClon;
        }

        public void AgregarDirector(Reparto reparto)
        {
            _directores.Add(reparto);
        }

        public void AgregarActor(Reparto reparto)
        {
            _actores.Add(reparto);
        }

        public void AgregarActuacion(Reparto reparto, string v)
        {
            Actuacion actuacionAAgregar = new Actuacion()
            {
                Actor = reparto,
                Papel = v
            };
            bool sePuede = true;
            foreach (Actuacion actuacion in _actuaciones)
            {
                if (actuacion.Actor.Nombre.Equals(reparto.Nombre) && actuacion.Papel.Equals(v))
                {
                    sePuede=false;
                }
            }

            if (sePuede)
            {
                _actuaciones.Add(actuacionAAgregar);
                if (!this.Actores.Contains(reparto))
                {
                    AgregarActor(reparto);
                }
            }
            else
            {
                throw new PeliculaInvalidaExcepcion("El actor ya realiza dicho papel.");
            }
            
        }

        public void EliminarActuacion(Reparto reparto, string v)
        {
            Actuacion aux = new Actuacion();
            foreach (Actuacion actuacion in _actuaciones)
            {
                if (actuacion.Actor.Nombre.Equals(reparto.Nombre) && actuacion.Papel.Equals(v))
                {
                    aux = actuacion;
                }
            }

            _actuaciones.Remove(aux);
        }
    }
}
