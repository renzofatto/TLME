using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using Dominio;
using Dominio.Excepciones;

namespace DominioTest
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void ValidarNombreUsuarioOK()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "unNombreCorrecto"
            };

            bool resultado = usuario.ValidarNombre();
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void ValidarNombreVacioTest()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = ""
            };

            bool resultado = usuario.ValidarNombre();
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void ValidarNombreMinimo10Test()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "unNombre"
            };

            bool resultado = usuario.ValidarNombre();
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void ValidarNombreMaximo20Test()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "unNombreDeMasDeVeinteCaracteres"
            };

            bool resultado = usuario.ValidarNombre();
        }

        [TestMethod]
        public void ValidarNombreAlfanumericoTest()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "unNombre12345"
            };

            bool resultado = usuario.ValidarNombre();
            Assert.IsTrue(resultado);
        }
        
        [TestMethod]
        public void ValidarMailUsuarioOk()
        {
            Usuario usuario = new Usuario()
            {
                Mail = "unUsuario@Mail.com"
            };

            bool resultado = usuario.ValidarMail();
            Assert.IsTrue(resultado);
        }
        
        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void ValidarMailInvalidoUsuarioTest()
        {
            Usuario usuario = new Usuario()
            {
                Mail = "unUsuario"
            };

            bool resultado = usuario.ValidarMail();
        }

        [TestMethod]
        public void ValidarContrasenaUsuarioOk()
        {
            string contrasena = "unaContrasena";
            Usuario usuario = new Usuario();
            usuario.Contrasena = contrasena;
            Assert.IsTrue(usuario.ValidarContrasena("unaContrasena"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void AsignarContrasenaIncorrectaTest()
        {
            string contrasena = "corta";
            Usuario usuario = new Usuario();
            usuario.Contrasena = contrasena;
        }
        
        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void ValidarContrasenaCortaUsuarioTest()
        {
            string contrasena = "corta";
            Usuario usuario = new Usuario()
            {
                Contrasena = contrasena
            };
        }

        [TestMethod]
        public void ValidarHashContrasena()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "unaContrasena"
            };
            
            Assert.IsFalse(usuario.Contrasena.Equals("unaContrasena"));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void ValidarMinimoContrasena()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "corta"
            };
            bool resultado = usuario.ValidarContrasena("corta");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void ValidarMaximoContrasena()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasenaDemasiadoLargaNoValida"
            };
            bool resultado = usuario.ValidarContrasena("contrasenaDemasiadoLargaNoValida");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void ValidarContrasenaVacio()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = ""
            };
            bool resultado = usuario.ValidarContrasena("");
        }
        
        [TestMethod]
        public void CoincideContrasenaUsuarioOk()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena"
            };

            bool resultado = usuario.CoincideContrasena("contrasena");
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void CoincideContrasenaInvalidaUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena"
            };

            bool resultado = usuario.CoincideContrasena("invalida");
            Assert.IsFalse(resultado);
        }
        
        [TestMethod]
        public void EsUsuarioAdministradorOk()
        {
            Usuario usuario = new Usuario()
            {
                Administrador = true
            };

            Assert.IsTrue(usuario.Administrador);
        }
        
        [TestMethod]
        public void EsUsuarioTest()
        {
            Usuario usuario = new Usuario()
            {
                Mail = "unMail"
            };

            Assert.IsFalse(usuario.Administrador);
        }

        [TestMethod]
        public void ObtenerCantidadPerfilesOk()
        {
            Perfil unPerfil = new Perfil()
            {
                Alias = "unAlias",
                Pin = 12345
            };
            List<Perfil> listaPerfiles = new List<Perfil>();
            listaPerfiles.Add(unPerfil);
            Usuario usuario = new Usuario()
            {
                Perfiles = listaPerfiles
            };
            Assert.IsTrue(usuario.Perfiles.Count==1);
        }

        [TestMethod]
        public void AgregarPerfilOk()
        {
            Usuario usuario = new Usuario();
            Perfil unPerfil = new Perfil()
            {
                Alias = "unAlias",
                Pin = 12345
            };
            usuario.AgregarPerfil(unPerfil);
            Assert.IsTrue(usuario.Perfiles.Count==1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void AgregarPerfilRepetidoTest()
        {
            Usuario usuario = new Usuario();
            Perfil unPerfil = new Perfil()
            {
                Alias = "unAlias",
                Pin = 12345
            };
            Perfil unPerfil2 = new Perfil()
            {
                Alias = "unAlias",
                Pin = 12346
            };
            usuario.AgregarPerfil(unPerfil);
            usuario.AgregarPerfil(unPerfil2);
        }
        
        [TestMethod]
        public void EliminarPerfilOk()
        {
            Usuario usuario = new Usuario();
            Perfil unPerfil = new Perfil()
            {
                Alias = "unAlias",
                Pin = 12345
            };
            usuario.EliminarPerfil(unPerfil);
            Assert.IsTrue(usuario.Perfiles.Count==0);
        }
        
        [TestMethod]
        public void Agregar4PerfilesTest()
        {
            Usuario usuario = new Usuario();
            Perfil perfil1 = new Perfil()
            {
                Alias = "unAlias",
                Pin = 12345
            };
            Perfil perfil2 = new Perfil()
            {
                Alias = "unAliass",
                Pin = 12346
            };
            Perfil perfil3 = new Perfil()
            {
                Alias = "unAliasss",
                Pin = 12347
            };
            Perfil perfil4 = new Perfil()
            {
                Alias = "unAliassss",
                Pin = 12348
            };
            usuario.AgregarPerfil(perfil1);
            usuario.AgregarPerfil(perfil2);
            usuario.AgregarPerfil(perfil3);
            usuario.AgregarPerfil(perfil4);
            Assert.IsTrue(usuario.Perfiles.Count==4);
        }
        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void Agregar5PerfilesTest()
        {
            Usuario usuario = new Usuario();
            Perfil perfil1 = new Perfil()
            {
                Alias = "unAlias",
                Pin = 12345
            };
            Perfil perfil2 = new Perfil()
            {
                Alias = "unAliass",
                Pin = 12346
            };
            Perfil perfil3 = new Perfil()
            {
                Alias = "unAliasss",
                Pin = 12347
            };
            Perfil perfil4 = new Perfil()
            {
                Alias = "unAliassss",
                Pin = 12348
            };
            Perfil perfil5 = new Perfil()
            {
                Alias = "unAliasssss",
                Pin = 12349
            };
            usuario.AgregarPerfil(perfil1);
            usuario.AgregarPerfil(perfil2);
            usuario.AgregarPerfil(perfil3);
            usuario.AgregarPerfil(perfil4);
            usuario.AgregarPerfil(perfil5);
            
        }

        [TestMethod]
        public void VerificarSiEstaLogeadoOk()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena",
                Mail = "unMail",
                Nombre = "unNombreUsuario",
                Logged = true
            };
            Assert.IsTrue(usuario.Logged);
        }
        
        [TestMethod]
        public void LoguearUnPerfilOk()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena",
                Mail = "unMail",
                Nombre = "unNombreUsuario",
                Logged = true
            };
            Perfil perfil1 = new Perfil()
            {
                Alias = "perfil",
                Pin = 12345
            };
            usuario.AgregarPerfil(perfil1);
            usuario.LoguearA(perfil1);
            Assert.IsTrue(perfil1.Logged);
        }

        [TestMethod]
        public void CerrarSesionTodoLosPerfilesOk()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena",
                Mail = "unMail",
                Nombre = "unNombreUsuario",
                Logged = true
            };
            Perfil perfil1 = new Perfil()
            {
                Alias = "perfil",
                Pin = 12345
            };
            usuario.AgregarPerfil(perfil1);
            usuario.LoguearA(perfil1);
            usuario.CerrarSesionPerfiles();
            Assert.IsFalse(perfil1.Logged);
        }
        
        [TestMethod]
        public void CerrarSesionTodoLosPerfilesTest()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena",
                Mail = "unMail",
                Nombre = "unNombreUsuario",
                Logged = true
            };
            Perfil perfil1 = new Perfil()
            {
                Alias = "perfil1",
                Pin = 12345
            };
            Perfil perfil2 = new Perfil()
            {
                Alias = "perfil2",
                Pin = 12346
            };
            usuario.AgregarPerfil(perfil1);
            usuario.AgregarPerfil(perfil2);
            usuario.LoguearA(perfil1);
            usuario.LoguearA(perfil2);
            usuario.CerrarSesionPerfiles();
            Assert.IsFalse(perfil1.Logged && perfil2.Logged);
        }

        [TestMethod]
        public void PerfilLogueadoOk()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena",
                Mail = "unMail",
                Nombre = "unNombreUsuario",
                Logged = true
            };
            Perfil perfil1 = new Perfil()
            {
                Alias = "perfil",
                Pin = 12345,
                Logged = true
            };
            usuario.AgregarPerfil(perfil1);
            Assert.IsTrue(usuario.PerfilLogueado().Alias.Equals("perfil"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void SettearContrasenaTest()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena",
                Mail = "unMail",
                Nombre = "unNombreUsuario",
                Logged = true
            };
            usuario.Contrasena = "corta";
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioInvalidoExcepcion))]
        public void NingunPerfilLogueadoTest()
        {
            Usuario usuario = new Usuario()
            {
                Contrasena = "contrasena",
                Mail = "unMail",
                Nombre = "unNombreUsuario",
                Logged = true
            };
            Perfil perfil1 = new Perfil()
            {
                Alias = "perfil",
                Pin = 12345,
                Logged = false
            };
            usuario.AgregarPerfil(perfil1);
            usuario.PerfilLogueado();
        }
    }
}
