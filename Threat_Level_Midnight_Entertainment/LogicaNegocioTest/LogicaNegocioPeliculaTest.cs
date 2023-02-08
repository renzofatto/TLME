using Dominio;
using Dominio.Excepciones;
using LogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositorioEnMemoria;
using System;

namespace LogicaNegocioTest
{
    [TestClass]
    public class LogicaNegocioPeliculaTest
    {
        [TestMethod]
        public void AgregarPeliculaTestOk()
        {
            Pelicula pelicula = new Pelicula()      
            {
                Nombre = "unNombre"
            };
            IRepositorioPeliculas repositorioPeliculas= new RepositorioPeliculasImpl();
            LogicaNegocioPelicula logicaPelicula= new LogicaNegocioPelicula(repositorioPeliculas);
            logicaPelicula.Agregar(pelicula);

            Assert.AreEqual(1, repositorioPeliculas.ObtenerPeliculas().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(PeliculaInvalidaExcepcion))]
        public void AgregarPeliculaNombreVacioTest()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = ""
            };
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(new RepositorioPeliculasImpl());
            logicaPelicula.Agregar(pelicula);
        }

        [TestMethod]
        [ExpectedException(typeof(LogicaNegocioPeliculaExcepcion))]
        public void AgregarPeliculaRepetidaTest()
        {
            Pelicula unaPeli = new Pelicula()
            {
                Nombre = "Titanic",
            };
            Pelicula otraPeli = new Pelicula()
            {
                Nombre = "Titanic",
            };

            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(new RepositorioPeliculasImpl());
            logicaPelicula.Agregar(unaPeli);
            logicaPelicula.Agregar(otraPeli);
        }

        [TestMethod]
        public void ObtenerPeliculaOk()
        {
            Pelicula unaPelicula= new Pelicula()
            {
                Nombre = "unNombreUsuarioA",
            };
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(new RepositorioPeliculasImpl());
            logicaPelicula.Agregar(unaPelicula);
            Assert.IsTrue(logicaPelicula.ObtenerPelicula().Count == 1);
        }

        [TestMethod]
        public void ObtenerPeliculaPorNombreOk()
        {
            Pelicula unaPelicula= new Pelicula()
            {
                Nombre = "unNombre",
            };
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(new RepositorioPeliculasImpl());
            logicaPelicula.Agregar(unaPelicula);
            Pelicula peliculaResultado = logicaPelicula.ObtenerPeliculaPorNombre("unNombre");
            Assert.IsTrue(peliculaResultado.Nombre.Equals("unNombre"));
        }

        [TestMethod]
        [ExpectedException(typeof(LogicaNegocioPeliculaExcepcion))]
        public void ObtenerPeliculaPorNombreTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unNombre",
            };
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(new RepositorioPeliculasImpl());
            logicaPelicula.Agregar(unaPelicula);
            Pelicula peliculaResultado = logicaPelicula.ObtenerPeliculaPorNombre("otroNombre");
        }

        [TestMethod]
        public void EliminarPeliculaOk()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unNombre",
            };
            IRepositorioPeliculas repositorioPeliculas = new RepositorioPeliculasImpl();
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(repositorioPeliculas);
            logicaPelicula.Agregar(unaPelicula);
            logicaPelicula.Eliminar(unaPelicula);
            Assert.IsTrue(logicaPelicula.ObtenerPelicula().Count==0);
        }
        
        [TestMethod]
        public void ClonarListaOk()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unNombre",
            };
            IRepositorioPeliculas repositorioPeliculas = new RepositorioPeliculasImpl();
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(repositorioPeliculas);
            logicaPelicula.Agregar(unaPelicula);
            LogicaNegocioPelicula logicaPeliculaClon = logicaPelicula.Clonar();
            Assert.IsTrue(logicaPeliculaClon.ObtenerPelicula().Count==1);
        }
        
        [TestMethod]
        public void ClonarListaTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unNombre",
                Puntaje = 2,
            };
            IRepositorioPeliculas repositorioPeliculas = new RepositorioPeliculasImpl();
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(repositorioPeliculas);
            logicaPelicula.Agregar(unaPelicula);
            LogicaNegocioPelicula logicaPeliculaClon = logicaPelicula.Clonar();
            Assert.IsTrue(logicaPeliculaClon.ObtenerPeliculaPorNombre("unNombre").Puntaje==0);
        }
        
        [TestMethod]
        public void ClonarGeneroPrincipalTest()
        {
            Genero unGenero = new Genero()
            {
                Nombre = "unNombreGenero",
                Puntaje = 2
            };
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unNombre",
                Puntaje = 2,
                GeneroPrincipal = unGenero
            };
            IRepositorioPeliculas repositorioPeliculas = new RepositorioPeliculasImpl();
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(repositorioPeliculas);
            logicaPelicula.Agregar(unaPelicula);
            LogicaNegocioPelicula logicaPeliculaClon = logicaPelicula.Clonar();
            Assert.IsTrue(logicaPeliculaClon.ObtenerPeliculaPorNombre("unNombre").Puntaje==0);
        }
        
        [TestMethod]
        public void ClonarGeneroSecundarioTest()
        {
            Genero unGenero = new Genero()
            {
                Nombre = "unNombreGenero",
                Puntaje = 2
            };
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unNombre",
                Puntaje = 2,
            };
            unaPelicula.GeneroSecundario.Add(unGenero);
            IRepositorioPeliculas repositorioPeliculas = new RepositorioPeliculasImpl();
            LogicaNegocioPelicula logicaPelicula = new LogicaNegocioPelicula(repositorioPeliculas);
            logicaPelicula.Agregar(unaPelicula);
            LogicaNegocioPelicula logicaPeliculaClon = logicaPelicula.Clonar();
            Assert.IsTrue(logicaPeliculaClon.ObtenerPeliculaPorNombre("unNombre").GeneroSecundario[0].Nombre.Equals("unNombreGenero"));
        }
    }
}
