using Dominio;
using LogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositorioEnMemoria;
using System;
using Dominio.Excepciones;

namespace LogicaNegocioTest
{
    [TestClass]
    public class LogicaNegocioUsuarioTest
    {
        [TestMethod]
        public void AgregarUsuarioTestOk()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "unNombreValido"
            };
            IRepositorioUsuarios repositorioUsuarios = new RepositorioUsuariosImpl();
            LogicaNegocioUsuario logicaUsuario = new LogicaNegocioUsuario(repositorioUsuarios);
            logicaUsuario.Agregar(usuario);

            Assert.AreEqual(1, repositorioUsuarios.ObtenerUsuarios().Count);
        }
        
        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void AgregarUsuarioContrasenaCortaTest()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "unNombreValido",
                Contrasena = "corta"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void AgregarUsuarioVacioTest()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = ""
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(LogicaNegocioUsuarioExcepcion))]
        public void AgregarUsuarioNombreRepetidoTest()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreIgual"
            };
            Usuario usuarioB = new Usuario()
            {
                Nombre = "unNombreIgual"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            logicaCliente.Agregar(usuarioB);
        }

        [TestMethod]
        [ExpectedException(typeof(LogicaNegocioUsuarioExcepcion))]
        public void AgregarUsuarioMailRepetidoTest()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailIgual"
            };
            Usuario usuarioB = new Usuario()
            {
                Nombre = "otroNombre",
                Mail = "unMailIgual"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            logicaCliente.Agregar(usuarioB);
        }

        [TestMethod]
        public void ObtenerUsuarioOk()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            Assert.IsTrue(logicaCliente.ObtenerUsuarios().Count == 1);
        }

        [TestMethod]
        public void ExisteUsuarioOk()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario"
            };
            Usuario usuarioAuxiliar = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            Assert.IsTrue(logicaCliente.Existe(usuarioAuxiliar));
        }
        
        [TestMethod]
        [ExpectedException(typeof(LogicaNegocioUsuarioExcepcion))]
        public void ExisteUsuarioInvalidoTest()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario"
            };
            Usuario usuarioAuxiliar = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "otroMail"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            logicaCliente.Existe(usuarioAuxiliar);
        }
        
        [TestMethod]
        public void ObtenerContrasenaDeOK()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario",
                Contrasena = "unaContrasena"
            };
            Usuario usuarioAuxiliar = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "otroMail",
                Contrasena = "unaContrasena"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            Assert.IsTrue(logicaCliente.ObtenerContrasenaDe(usuarioA).Equals(usuarioAuxiliar.Contrasena));
        }
        
        [TestMethod]
        public void ObtenerContrasenaDeTest()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario",
                Contrasena = "unaContrasena"
            };
            Usuario usuarioAuxiliar = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "otroMail",
                Contrasena = "otraContrasena"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            Assert.IsFalse(logicaCliente.ObtenerContrasenaDe(usuarioA).Equals(usuarioAuxiliar.Contrasena));
        }
        
        [TestMethod]
        public void ObtenerUnUsuarioPorMailOk()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario",
                Contrasena = "unaContrasena"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            Usuario usuarioResultado = logicaCliente.ObtenerUsuariosPorMail("unMailUsuario");
            Assert.IsTrue(usuarioResultado.Nombre.Equals("unNombreUsuarioA"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(LogicaNegocioUsuarioExcepcion))]
        public void ObtenerUnUsuarioPorMailTest()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario",
                Contrasena = "unaContrasena"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            Usuario usuarioResultado = logicaCliente.ObtenerUsuariosPorMail("otroMail");
        }
        
        [TestMethod]
        public void ObtenerUnUsuarioLogueadoOk()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario",
                Contrasena = "unaContrasena"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            logicaCliente.UsuarioLogueado = usuarioA;
            Assert.IsTrue(logicaCliente.UsuarioLogueado.Mail.Equals(usuarioA.Mail));
        } 
        
        [TestMethod]
        public void SetearUsuarioLogueadoOk()
        {
            Usuario usuarioA = new Usuario()
            {
                Nombre = "unNombreUsuarioA",
                Mail = "unMailUsuario",
                Contrasena = "unaContrasena"
            };
            LogicaNegocioUsuario logicaCliente = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaCliente.Agregar(usuarioA);
            logicaCliente.UsuarioLogueado = usuarioA;
            Assert.IsTrue(logicaCliente.UsuarioLogueado.Mail.Equals(usuarioA.Mail));
        }

        
    }
}
