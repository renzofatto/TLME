using Dominio;
using Dominio.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DominioTest
{
    [TestClass]
    public class GeneroTest
    {
        [TestMethod]
        [ExpectedException(typeof(GeneroInvalidoExcepcion))]
        public void NombreNoVacioOk()
        {
            Genero genero = new Genero()
            {
                Nombre = ""
            };
        }
        
        [TestMethod]
        public void DescripcionOk()
        {
            Genero genero = new Genero()
            {
                Descripcion = "Una descripcion"
            };
            Assert.IsTrue(genero.Descripcion.Equals("Una descripcion"));
        }
        
        [TestMethod]
        public void DescripcionVaciaOk()
        {
            Genero genero = new Genero();
            Assert.IsTrue(genero.Descripcion.Equals("Sin descripcion"));
        }
        
        [TestMethod]
        public void ListaPeliculaAsociadasOk()
        {
            Genero genero = new Genero()
            {
                Peliculas = new List<Pelicula>()
            };
            Assert.IsTrue(genero.Peliculas.Count == 0);
        }
        
        [TestMethod]
        public void AgregarPeliculaOk()
        {
            Genero terror = new Genero()
            {
                Nombre = "Terror"
            };
            Pelicula llorona = new Pelicula()
            {
                Nombre = "Llorona"
            };
            terror.AgregarPelicula(llorona);
            Assert.IsTrue(terror.Peliculas.Count == 1);
        }
        
        [TestMethod]
        public void VerificarCantidadPeliculasAlInicializarOk()
        {
            Genero genero = new Genero()
            {
                Nombre = "unGenero"
            };
            Assert.IsTrue(genero.Peliculas.Count == 0);
        } 
        
        [TestMethod]
        public void PuntuarGeneroOk()
        {
            Genero genero = new Genero()
            {
                Puntaje = 4
            };
            Assert.IsTrue(genero.Puntaje == 4);
        }
        
        [TestMethod]
        public void ToStringOk()
        {
            Genero genero = new Genero()
            {
                Nombre= "genero"
            };
            Assert.AreEqual("genero", genero.ToString());
        }
        
        [TestMethod]
        public void ClonarOk()
        {
            Genero genero = new Genero()
            {
                Nombre= "genero"
            };
            Genero generoClonado = genero.Clon();
            Assert.AreEqual(generoClonado.ToString(), genero.ToString());
        }
        
        [TestMethod]
        public void ClonarTest()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombre"
            };
            Genero genero = new Genero()
            {
                Nombre= "genero"
            };
            genero.Peliculas.Add(pelicula);
            Genero generoClonado = genero.Clon();
            Assert.IsTrue(generoClonado.Peliculas.Count==1);
        }
        
        [TestMethod]
        public void ClonarPeliculasTest()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unNombre",
                Puntaje = 2
            };
            Genero genero = new Genero()
            {
                Nombre= "genero"
            };
            genero.Peliculas.Add(pelicula);
            Genero generoClonado = genero.Clon();
            Assert.IsTrue(generoClonado.Peliculas[0].Puntaje==0);
        }

        [TestMethod]
        public void ClonarPeliculasCompletaTest()
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

            Pelicula pelicula = new Pelicula
            {
                Nombre = "unNombre",
                Patrocinada = true,
                Puntaje = 2,
                ATP = true,
                Calificacion = 2,
                Reproducciones = 0,
                Descripcion = "unaDescripcion",
                Estreno = fecha,
                Actores = actores,
                Actuaciones = actuaciones,
                Directores = directores,
                GeneroPrincipal = generoPrincipal,
                GeneroSecundario = null,
                Vista = true,
                Imagen = "unaImagen",
            };

            Genero genero = new Genero()
            {
                Nombre = "genero"
            };

            genero.Peliculas.Add(pelicula);

            Genero generoClonado = genero.Clon();
            
            Assert.IsTrue(generoClonado.Peliculas[0].Puntaje == 0 
                          && generoClonado.Peliculas[0].Vista == false 
                          && generoClonado.Peliculas[0].ATP == true
                          && generoClonado.Peliculas[0].Patrocinada == true
                          && generoClonado.Peliculas[0].Actores[0].Nombre.Equals("nombreActor")
                          && generoClonado.Peliculas[0].Actuaciones[0].Actor.Nombre.Equals("nombreActor")
                          && generoClonado.Peliculas[0].Actuaciones[0].Papel.Equals("unPapel") 
                          && generoClonado.Peliculas[0].Calificacion == 0 
                          && generoClonado.Peliculas[0].Descripcion.Equals("unaDescripcion") 
                          && generoClonado.Peliculas[0].Directores[0].Nombre.Equals("nombreDirector") 
                          && generoClonado.Peliculas[0].Estreno.Equals(fecha) 
                          && generoClonado.Peliculas[0].GeneroPrincipal.Nombre.Equals(generoPrincipal.Nombre) 
                          && generoClonado.Peliculas[0].Imagen.Equals("unaImagen")
                          );
        }
    }
}
