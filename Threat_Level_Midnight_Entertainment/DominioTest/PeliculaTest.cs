using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using Dominio;
using Dominio.Excepciones;

namespace DominioTest
{
    [TestClass]
    public class PeliculaTest
    {
        [TestMethod]
        public void ValidarNombrePeliculaOK()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto"
            };

            bool resultado = pelicula.ValidarNombre();
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(PeliculaInvalidaExcepcion))]
        public void ValidarNombreVacioTest()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = ""
            };

            bool resultado = pelicula.ValidarNombre();
        }

        [TestMethod]
        public void EsPatrocinadaOK()
        {
            Pelicula pelicula = new Pelicula()
            {
                Patrocinada = true
            };
            Assert.IsTrue(pelicula.Patrocinada);
        }

        [TestMethod]
        public void NoEsPatrocinadaTest()
        {
            Pelicula pelicula = new Pelicula()
            {
                Patrocinada = true
            };
            pelicula.Patrocinada = false;
            Assert.IsFalse(pelicula.Patrocinada);
        }


        [TestMethod]
        public void DescripcionOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Descripcion = "Esta es una descripcion"
            };
            Assert.IsTrue(pelicula.Descripcion.Equals("Esta es una descripcion"));
        }
        
        [TestMethod]
        public void SetDescripcionOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Descripcion = "Esta es una descripcion"
            };
            pelicula.Descripcion = "Otra descripcion";
            Assert.IsTrue(pelicula.Descripcion.Equals("Otra descripcion"));
        }
        
        [TestMethod]
        public void DescripcionVaciaTest()
        {
            Pelicula pelicula = new Pelicula();
            Assert.IsTrue(pelicula.Descripcion.Equals("Sin descripcion"));
        }
        
        [TestMethod]
        public void PeliculaATPOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                ATP = true
            };
            Assert.IsTrue(pelicula.ATP);
        }
        
        [TestMethod]
        public void PeliculaATPTest()
        {
            Pelicula pelicula = new Pelicula()
            {
                ATP = true
            };
            pelicula.ATP = false;
            Assert.IsFalse(pelicula.ATP);
        }
        
        [TestMethod]
        public void CalificarPeliculaPositivaOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0
            };
            pelicula.Calificacion++;
            Assert.IsTrue(pelicula.Calificacion == 1);
        }
        
        [TestMethod]
        public void CalificarPeliculaMuyPositivaOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 20
            };
            pelicula.Calificacion+= 2;
            Assert.IsTrue(pelicula.Calificacion == 22);
        }
        
        [TestMethod]
        public void CalificarPeliculaNegativaOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 2
            };
            pelicula.Calificacion--;
            Assert.IsTrue(pelicula.Calificacion == 1);
        }
        
        [TestMethod]
        public void CalificarPeliculaNegativaConMetodoOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionNegativa();
            Assert.IsTrue(pelicula.Calificacion == -1);
        }
        
        [TestMethod]
        public void CalificarPeliculaYGeneroNegativaConMetodoOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror" 
            };

            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionNegativa();
            Assert.IsTrue(pelicula.Calificacion == genero.Puntaje && pelicula.Calificacion == -1);
        }
       
        [TestMethod]
        public void CalificarPeliculaPositivaConMetodoOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionPositiva();
            Assert.IsTrue(pelicula.Calificacion == genero.Puntaje && pelicula.Calificacion == 1);
        }
        
        [TestMethod]
        public void CalificarPeliculaMuyPositivaConMetodoOk()
        {
            Genero generoP = new Genero
            {
                Nombre = "terror"
            };
            Genero generoS = new Genero
            {
                Nombre = "comedia"
            };
            List<Genero> generoSec = new List<Genero>();
            generoSec.Add(generoS);
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                GeneroPrincipal = generoP,
                GeneroSecundario = generoSec
            };
            pelicula.CalificacionMuyPositiva();
            Assert.IsTrue(pelicula.Calificacion == generoP.Puntaje && pelicula.Calificacion == 2 && pelicula.GeneroSecundario[0].Puntaje == 1);
        }
        
        [TestMethod]
        public void CantidadDeReproduccionesOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Reproducciones = 1
            };
            Assert.IsTrue(pelicula.Reproducciones == 1);
        }
        
        [TestMethod]
        public void PuntajePeliculaOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Puntaje = 1
            };
            Assert.IsTrue(pelicula.Puntaje == 1);
        }
        
        [TestMethod]
        public void PuntajePeliculaSegunReproduccionesOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Puntaje = 1,
                Reproducciones = 0
            };
            pelicula.Reproducirse();
            Assert.IsTrue(pelicula.Puntaje == 2 && pelicula.Reproducciones == 1 );
        }

        [TestMethod]
        public void CalificarPositivaPuntajeOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                Puntaje = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionPositiva();
            Assert.IsTrue(pelicula.Calificacion == 1 && pelicula.Puntaje == 1);
        }
        
        [TestMethod]
        public void CalificarMuyPositivaPuntajeOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                Puntaje = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionMuyPositiva();
            Assert.IsTrue(pelicula.Calificacion == 2 && pelicula.Puntaje == 2);
        }
        
        [TestMethod]
        public void CalificarNegativaPuntajeOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                Puntaje = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionNegativa();
            Assert.IsTrue(pelicula.Calificacion == -1 && pelicula.Puntaje == -1);
        }

        [TestMethod]
        public void CalificarNegativa2VecesOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                Puntaje = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionNegativa();
            pelicula.CalificacionNegativa();
            Assert.IsTrue(pelicula.Calificacion == -1 && pelicula.Puntaje == -1);
        }
        
        [TestMethod]
        public void CalificarPositiva2VecesOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                Puntaje = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionPositiva();
            pelicula.CalificacionPositiva();
            Assert.IsTrue(pelicula.Calificacion == 1 && pelicula.Puntaje == 1);
        }
        
        [TestMethod]
        public void CalificarMuyPositiva2VecesOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                Puntaje = 0,
                GeneroPrincipal = genero
            };
            pelicula.CalificacionMuyPositiva();
            pelicula.CalificacionMuyPositiva();
            Assert.IsTrue(pelicula.Calificacion == 2 && pelicula.Puntaje == 2);
        }

        [TestMethod]
        public void CalificarYVisualizarOk()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                Puntaje = 0,
                GeneroPrincipal = genero
            };
            pelicula.Visualizar();
            pelicula.CalificacionMuyPositiva();
            Assert.IsTrue(pelicula.Puntaje == 3 && pelicula.GeneroPrincipal.Puntaje == 3);
        }
        
        [TestMethod]
        public void CalificarYVisualizarTest()
        {
            Genero genero = new Genero
            {
                Nombre = "terror"
            };
            Pelicula pelicula = new Pelicula()
            {
                Calificacion = 0,
                Puntaje = 0,
                GeneroPrincipal = genero
            };
            pelicula.Visualizar();
            pelicula.CalificacionMuyPositiva();
            pelicula.CalificacionPositiva();
            pelicula.Visualizar();
            pelicula.CalificacionNegativa();
            pelicula.Visualizar();
            pelicula.CalificacionPositiva();
            Assert.IsTrue(pelicula.Puntaje == 2 && pelicula.GeneroPrincipal.Puntaje == 2);
        }

        [TestMethod]
        public void GeneroPrincipalOk()
        {
            Genero terror = new Genero()
            {
                Nombre = "Terror",
                Descripcion = "Mucho terror"
            };

            Pelicula pelicula = new Pelicula()
            {
                GeneroPrincipal = terror
            };
            Assert.IsTrue(pelicula.GeneroPrincipal.Nombre.Equals("Terror"));
        }
        
        [TestMethod]
        public void GeneroSecundarioOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                GeneroSecundario = new List<Genero>()
            };
            Assert.IsTrue(pelicula.GeneroSecundario.Count == 0 );
        }

        [TestMethod]
        public void AgregarGeneroSecundarioOk()
        {
            Genero terror = new Genero()
            {
                Nombre = "Terror",
                Descripcion = "Mucho terror"
            };

            Pelicula pelicula = new Pelicula();
            pelicula.AgregarGeneroSecundario(terror);
            Assert.IsTrue(pelicula.GeneroSecundario.Count == 1);
        }

        [TestMethod]
        public void PeliculaVistaOK()
        {
            Pelicula pelicula = new Pelicula()
            {
                Vista = true
            };
            Assert.IsTrue(pelicula.Vista);
        }

        [TestMethod]
        public void ValidarImagenPeliculaOK()
        {
            Pelicula pelicula = new Pelicula()
            {
                Imagen = "pathImagen"
            };
            Assert.AreEqual(pelicula.Imagen, "pathImagen");
        }

        [TestMethod]
        public void ToStringOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "Titanic"
            };
            Assert.AreEqual("Titanic", pelicula.ToString());
        }
        
        [TestMethod]
        public void ClonarOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "Titanic"
            };
            Pelicula peliculaClonada = pelicula.Clon();
            Assert.AreEqual(peliculaClonada.ToString(), pelicula.ToString());
        }
        
        [TestMethod]
        public void ClonarTest()
        {
            Genero terror = new Genero()
            {
                Nombre = "Terror",
                Descripcion = "Mucho terror"
            };

            Pelicula pelicula = new Pelicula()
            {
                Nombre = "Titanic",
                GeneroPrincipal = terror
            };
            pelicula.CalificacionPositiva();
            pelicula.Visualizar();
            Pelicula peliculaClonada = pelicula.Clon();
            Assert.IsTrue(peliculaClonada.Vista == false && peliculaClonada.Puntaje==0);
        }

        [TestMethod]
        public void AgregarDirectorOK()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto"
            };
            Reparto reparto = new Reparto()
            {
                Nombre = "Nombre",
            };
            pelicula.AgregarDirector(reparto);
            Assert.IsTrue(pelicula.Directores.Count == 1);
        }
        
        [TestMethod]
        public void AgregarActorOK()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto"
            };
            Reparto reparto = new Reparto()
            {
                Nombre = "Nombre",
            };
            pelicula.AgregarActor(reparto);
            Assert.IsTrue(pelicula.Actores.Count == 1);
        }
        
        [TestMethod]
        public void AgregarActuacionOK()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto"
            };
            Reparto reparto = new Reparto()
            {
                Nombre = "Nombre",
            };
            pelicula.AgregarActuacion(reparto, "Asesino");
            Assert.IsTrue(pelicula.Actuaciones[0].Papel.Equals("Asesino"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(PeliculaInvalidaExcepcion))]
        public void AgregarActuacionRepetidaTest()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto"
            };
            Reparto reparto = new Reparto()
            {
                Nombre = "Nombre",
            };
            pelicula.AgregarActuacion(reparto, "Asesino");
            pelicula.AgregarActuacion(reparto, "Asesino");
        }

        [TestMethod]
        public void AgregarActuacionMismoActorOtroPapelTest()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto"
            };
            Reparto reparto = new Reparto()
            {
                Nombre = "Nombre",
            };
            pelicula.AgregarActuacion(reparto, "Asesino");
            pelicula.AgregarActuacion(reparto, "Policia");
            Assert.IsTrue(pelicula.Actuaciones[1].Papel.Equals("Policia"));
        }

        [TestMethod]
        public void AgregarActoresConActuacionOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto"
            };
            Reparto reparto = new Reparto()
            {
                Nombre = "Nombre",
            };
            pelicula.AgregarActuacion(reparto, "Asesino");
            Assert.IsTrue(pelicula.Actores[0].Nombre.Equals("Nombre"));
        }

        [TestMethod]
        public void EliminarActuacionOK()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto"
            };
            Reparto reparto = new Reparto()
            {
                Nombre = "Nombre",
            };
            pelicula.AgregarActuacion(reparto, "Asesino");
            pelicula.EliminarActuacion(reparto, "Asesino");
            Assert.IsTrue(pelicula.Actuaciones.Count==0);
        }

        [TestMethod]
        public void AgregarFechaEstrenoOk()
        {
            DateTime estreno = new DateTime(2022,11,11);
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombreCorrecto",
                Estreno = estreno
            };
            Assert.IsTrue(pelicula.Estreno.Month == 11);
        }

        [TestMethod]
        public void ClonarCompletoTest()
        {
            DateTime fecha = new DateTime(2000, 10, 06);

            Genero generoPrincipal = new Genero
            {
                Nombre = "generoPrincipal",
                Descripcion = "descripcionGeneroPrincipal",
                Peliculas = null,
                Puntaje = 0
            };
            
            Reparto actor = new Reparto
            {
                Nombre = "nombreActor",
                FechaNacimiento = default,
                Imagen = null,
            };
            List<Reparto> actores = new List<Reparto>();
            actores.Add(actor);
            
            Reparto director = new Reparto
            {
                Nombre = "nombreDirector",
                FechaNacimiento = default,
                Imagen = null,
            };
            List<Reparto> directores = new List<Reparto>();
            directores.Add(director);
            
            Actuacion actuacion = new Actuacion
            {
                Papel = "unPapel",
                Actor = actor
            };
            List<Actuacion> actuaciones = new List<Actuacion>();
            actuaciones.Add(actuacion);

            Genero terror = new Genero
            {
                Nombre = "Terror",
                Descripcion = "Mucho terror",
                Peliculas = null,
                Puntaje = 0
            };
            Pelicula pelicula = new Pelicula
            {
                Nombre = "Titanic",
                Patrocinada = true,
                Descripcion = "unaDescripcion",
                ATP = true,
                Calificacion = 2,
                Reproducciones = 1,
                Puntaje = 2,
                GeneroPrincipal = terror,
                GeneroSecundario = null,
                Vista = true,
                Imagen = "unaImagen",
                Directores = directores,
                Actores = actores,
                Actuaciones = actuaciones,
                Estreno = fecha,

            };
            
            Pelicula peliculaClonada = pelicula.Clon();

            Assert.IsTrue(peliculaClonada.Nombre.Equals("Titanic")
                          && peliculaClonada.Patrocinada == true
                          && peliculaClonada.Descripcion.Equals("unaDescripcion")
                          && peliculaClonada.ATP == true
                          && peliculaClonada.Calificacion == 0
                          && peliculaClonada.Reproducciones == 0 
                          && peliculaClonada.Puntaje == 0
                          && peliculaClonada.GeneroPrincipal.Nombre.Equals(terror.Nombre)
                          && peliculaClonada.GeneroSecundario == null
                          && peliculaClonada.Vista == false
                          && peliculaClonada.Imagen.Equals("unaImagen")
                          && peliculaClonada.Directores[0].Nombre.Equals("nombreDirector")
                          && peliculaClonada.Actores[0].Nombre.Equals("nombreActor")
                          && peliculaClonada.Actuaciones[0].Papel.Equals("unPapel")
                          && peliculaClonada.Estreno.Equals(fecha)
                          );
        }
    }
}
