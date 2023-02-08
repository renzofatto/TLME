using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DominioTest
{
    [TestClass]
    public class ActuacionTest
    {
        [TestMethod]
        public void ActuacionOk()
        {
            Actuacion actuacion = new Actuacion()
            {
                Papel = "unPapel"
            };
            Assert.AreEqual(actuacion.Papel, "unPapel");
        }
        [TestMethod]
        public void ActuacionActorOk()
        {
            Reparto actor = new Reparto()
            {
                Nombre = "unNombre"
            };
            Actuacion actuacion = new Actuacion()
            {
                Papel = "unPapel",
                Actor = actor
            };
            Assert.AreEqual(actuacion.Actor.Nombre, "unNombre");
        }

        [TestMethod]
        public void ToStringTest()
        {
            Reparto actor = new Reparto()
            {
                Nombre = "unNombre"
            };
            Actuacion actuacion = new Actuacion()
            {
                Papel = "unPapel",
                Actor = actor
            };
            Assert.IsTrue(actuacion.ToString().Equals("unNombre - unPapel"));
        }
    }
}
