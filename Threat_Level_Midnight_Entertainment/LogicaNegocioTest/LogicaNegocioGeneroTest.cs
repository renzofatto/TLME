using Dominio;
using Dominio.Excepciones;
using LogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositorioEnMemoria;
using System;

namespace LogicaNegocioTest
{
    [TestClass]
    public class LogicaNegocioGeneroTest
    {
        [TestMethod]
        public void AgregarGeneroTestOk()
        {
            Genero genero = new Genero()
            {
                Nombre = "unGenero"
            };
            IRepositorioGeneros repositorioGeneros = new RepositorioGenerosImpl();
            LogicaNegocioGenero logicaGenero= new LogicaNegocioGenero(repositorioGeneros);
            logicaGenero.Agregar(genero);

            Assert.AreEqual(1, repositorioGeneros.ObtenerGeneros().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(LogicaNegocioGeneroExcepcion))]
        public void AgregarGeneroRepetidoTest()
        {
            Genero unGenero = new Genero()
            {
                Nombre = "unNombreGenero"
            };
            
            Genero otroGenero = new Genero()
            {
                Nombre = "unNombreGenero"
            };
            LogicaNegocioGenero logicaGenero = new LogicaNegocioGenero(new RepositorioGenerosImpl());
            logicaGenero.Agregar(unGenero);
            logicaGenero.Agregar(otroGenero);
        }

        [TestMethod]
        public void EliminarGeneroOk()
        {
            Genero genero = new Genero()
            {
                Nombre = "unGenero"
            };
            IRepositorioGeneros repositorioGeneros = new RepositorioGenerosImpl();
            LogicaNegocioGenero logicaGenero= new LogicaNegocioGenero(repositorioGeneros);
            logicaGenero.Eliminar(genero);
            Assert.IsTrue(logicaGenero.ObtenerGeneros().Count == 0);
        }
        
        [TestMethod]
        [ExpectedException(typeof(LogicaNegocioGeneroExcepcion))]
        public void EliminarGeneroTest()
        {
            Genero genero = new Genero()
            {
                Nombre = "unGenero"
            };
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "pelicula"
            };
            genero.AgregarPelicula(pelicula);
            IRepositorioGeneros repositorioGeneros = new RepositorioGenerosImpl();
            LogicaNegocioGenero logicaGenero= new LogicaNegocioGenero(repositorioGeneros);
            logicaGenero.Eliminar(genero);
        }

        [TestMethod]
        public void ObtenerGenerosOk()
        {
            Genero unGenero = new Genero()
            {
                Nombre = "unGenero"
            };
            LogicaNegocioGenero logicaGenero = new LogicaNegocioGenero(new RepositorioGenerosImpl());
            logicaGenero.Agregar(unGenero);
            Assert.IsTrue(logicaGenero.ObtenerGeneros().Count == 1);
        }

        [TestMethod]
        public void ObtenerGeneroPorNombre()
        {
            Genero unGenero = new Genero()
            {
                Nombre = "Nombre",
                Descripcion = "descripcion nombre"

            };
            LogicaNegocioGenero logicaGenero = new LogicaNegocioGenero(new RepositorioGenerosImpl());
            logicaGenero.Agregar(unGenero);
            Genero generoResultado = logicaGenero.ObtenerGeneroPorNombre("Nombre");
            Assert.IsTrue(generoResultado.Descripcion.Equals("descripcion nombre"));
        }
        
        [TestMethod]
        public void ClonarOk()
        {
            Genero unGenero = new Genero()
            {
                Nombre = "Nombre",
                Descripcion = "descripcion nombre",
                Puntaje = 3

            };
            LogicaNegocioGenero logicaGenero = new LogicaNegocioGenero(new RepositorioGenerosImpl());
            logicaGenero.Agregar(unGenero);
            LogicaNegocioGenero logicaGeneroClon = logicaGenero.Clonar();
            Assert.IsTrue(logicaGeneroClon.ObtenerGeneros().Count == 1);
        }
        
        [TestMethod]
        public void ClonarTest()
        {
            Genero unGenero = new Genero()
            {
                Nombre = "Nombre",
                Descripcion = "descripcion nombre",
                Puntaje = 3

            };
            LogicaNegocioGenero logicaGenero = new LogicaNegocioGenero(new RepositorioGenerosImpl());
            logicaGenero.Agregar(unGenero);
            LogicaNegocioGenero logicaGeneroClon = logicaGenero.Clonar();
            Assert.IsTrue(logicaGeneroClon.ObtenerGeneros()[0].Puntaje == 0);
        }
    }
}
