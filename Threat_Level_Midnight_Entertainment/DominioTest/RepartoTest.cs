using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DominioTest
{
    [TestClass]
    public class RepartoTest
    {
        [TestMethod]
        public void NombreRepartoOk()
        {
            Reparto reparto = new Reparto()
            {
                Nombre = "Nombre"
            };
            Assert.AreEqual(reparto.Nombre, "Nombre");
        }
        
        [TestMethod]
        public void FechaNacimientoRepartoOk()
        {
            DateTime nacimiento = new DateTime(2002, 12, 24);
            Reparto reparto = new Reparto()
            {
                FechaNacimiento = nacimiento
            };
            Assert.AreEqual(reparto.FechaNacimiento, nacimiento);
        }

        [TestMethod]
        public void ImagenRepartoOk()
        {
            Reparto reparto = new Reparto()
            {
                Imagen = "pathImagen"
            };
            Assert.AreEqual(reparto.Imagen, "pathImagen");
        }
        
        [TestMethod]
        public void ToStringTest()
        {
            Reparto reparto = new Reparto()
            {
                Nombre = "unReparto",
            };
            Assert.IsTrue(reparto.ToString().Equals("unReparto"));
        }
    }
}
