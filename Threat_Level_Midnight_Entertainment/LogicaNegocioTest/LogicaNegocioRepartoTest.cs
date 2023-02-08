using Dominio;
using Dominio.Excepciones;
using LogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositorioEnMemoria;
using System;

namespace LogicaNegocioTest
{
    [TestClass]
    public class LogicaNegocioRepartoTest
    {
        [TestMethod]
        public void AgregarRepartoTestOk()
        {
            DateTime fecha = new DateTime(1997,10,24);
            Reparto reparto = new Reparto()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto= new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto= new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(reparto);

            Assert.AreEqual(1, repositorioReparto.ObtenerRepartos().Count);
        }

        [TestMethod]
        public void EliminarRepartoOk()
        {
            DateTime fecha = new DateTime(1997, 10, 24);
            Reparto reparto = new Reparto()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto = new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto = new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(reparto);
            logicaReparto.Eliminar(reparto);
            Assert.IsTrue(logicaReparto.ObtenerRepartos().Count == 0);
        }
        
        [TestMethod]
        public void EliminarDirectorOk()
        {
            DateTime fecha = new DateTime(1997, 10, 24);
            Director director = new Director()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto = new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto = new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(director);
            logicaReparto.Eliminar(director);
            Assert.IsTrue(logicaReparto.ObtenerRepartos().Count == 0);
        }

        [TestMethod]
        public void EliminarActorOk()
        {
            DateTime fecha = new DateTime(1997, 10, 24);
            Actor actor = new Actor()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto = new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto = new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(actor);
            logicaReparto.Eliminar(actor);
            Assert.IsTrue(logicaReparto.ObtenerRepartos().Count == 0);
        }

        [TestMethod]
        public void AgregarActorTestOk()
        {
            DateTime fecha = new DateTime(1997, 10, 24);
            Actor actor = new Actor()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto = new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto = new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(actor);

            Assert.AreEqual(1, repositorioReparto.ObtenerRepartos().Count);
        }

        [TestMethod]
        public void AgregarDirectorTestOk()
        {
            DateTime fecha = new DateTime(1997, 10, 24);
            Director director = new Director()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto = new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto = new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(director);

            Assert.AreEqual(1, repositorioReparto.ObtenerRepartos().Count);
        }
        
        [TestMethod]
        public void ObtenerRepartoOk()
        {
            DateTime fecha = new DateTime(1997, 10, 24);
            Director director = new Director()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto = new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto = new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(director);

            Assert.AreEqual(1, repositorioReparto.ObtenerRepartos().Count);
        }
        
        [TestMethod]
        public void ObtenerDirectoresOk()
        {
            DateTime fecha = new DateTime(1997, 10, 24);
            Director director = new Director()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto = new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto = new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(director);

            Assert.AreEqual(1, repositorioReparto.ObtenerDirectores().Count);
        }
        
        [TestMethod]
        public void ObtenerActoresOk()
        {
            DateTime fecha = new DateTime(1997, 10, 24);
            Actor actor= new Actor()
            {
                Nombre = "UnReparto",
                FechaNacimiento = fecha,
                Imagen = "path"
            };
            IRepositorioReparto repositorioReparto = new RepositorioRepartoImpl();
            LogicaNegocioReparto logicaReparto = new LogicaNegocioReparto(repositorioReparto);
            logicaReparto.Agregar(actor);

            Assert.AreEqual(1, repositorioReparto.ObtenerActores().Count);
        }
    }
}
