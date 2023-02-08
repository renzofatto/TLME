using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DominioTest
{
    [TestClass]
    public class DirectorTest
    {
        [TestMethod]
        public void NombreDirectorOk()
        {
            Director director = new Director()
            {
                Nombre = "Nombre"
            };
            Assert.AreEqual(director.Nombre, "Nombre");
        }

        [TestMethod]
        public void FechaNacimientoDirectorOk()
        {
            DateTime nacimiento = new DateTime(2002, 12, 24);
            Director director = new Director()
            {
                FechaNacimiento = nacimiento
            };
            Assert.AreEqual(director.FechaNacimiento, nacimiento);
        }

        [TestMethod]
        public void ImagenDirectorOk()
        {
            Director director = new Director()
            {
                Imagen = "pathImagen"
            };
            Assert.AreEqual(director.Imagen, "pathImagen");
        }

        [TestMethod]
        public void ToStringTest()
        {
            Director director = new Director()
            {
                Nombre = "Nombre"
            };
            Assert.IsTrue(director.ToString().Equals("Nombre"));
        }

        [TestMethod]
        public void AgregarPeliculaDirigidaOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unaPelicula"
            };

            Director director = new Director()
            {
                Nombre = "Nombre"
            };
            director.AgregarPeliculaDirigida(pelicula);

            Assert.IsTrue(director.ToString().Equals("Nombre"));
        }
    }
}
