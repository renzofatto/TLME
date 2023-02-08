using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DominioTest
{
    [TestClass]
    public class ActorTest
    {
        [TestMethod]
        public void NombreActorOk()
        {
            Actor actor = new Actor()
            {
                Nombre = "Nombre"
            };
            Assert.AreEqual(actor.Nombre, "Nombre");
        }

        [TestMethod]
        public void FechaNacimientoActorOk()
        {
            DateTime nacimiento = new DateTime(2002, 12, 24);
            Actor actor = new Actor()
            {
                FechaNacimiento = nacimiento
            };
            Assert.AreEqual(actor.FechaNacimiento, nacimiento);
        }

        [TestMethod]
        public void ImagenActorOk()
        {
            Actor actor = new Actor()
            {
                Imagen = "pathImagen"
            };
            Assert.AreEqual(actor.Imagen, "pathImagen");
        }

        [TestMethod]
        public void ToStringTest()
        {
            Actor actor = new Actor()
            {
                Nombre = "Brad Pitt"
            };
            Assert.IsTrue(actor.ToString().Equals("Brad Pitt"));
        }

        [TestMethod]
        public void AgregarPeliculaActuadaOk()
        {
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "unaPelicula"
            };

            Actor actor = new Actor()
            {
                Nombre = "Brad Pitt"
            };
            actor.AgregarPeliculaActuada(pelicula);

            Assert.IsTrue(actor.ToString().Equals("Brad Pitt"));
        }

    }
}
