using Dominio;
using Dominio.Excepciones;
using LogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositorioEnMemoria;
using System;
using System.Collections.Generic;

namespace DominioTest
{
    [TestClass]
    public class PerfilTest
    {
        [TestMethod]
        public void ValidarAliasPerfilOk()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "unAlias"
            };

            bool resultado = perfil.ValidarAlias();
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilInvalidoExcepcion))]
        public void ValidarAliasPerfilNumerico()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "unAlias1"
            };

            bool resultado = perfil.ValidarAlias(); 
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilInvalidoExcepcion))]
        public void ValidarAliasMinimoCaracteres()
        {
            Perfil perfil = new Perfil()
            {
                Alias = ""
            };

            bool resultado = perfil.ValidarAlias();
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilInvalidoExcepcion))]
        public void ValidarAliasMaximoCaracteres()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "unAliasMuyLargoInvalido"
            };

            bool resultado = perfil.ValidarAlias();
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarPinPerfilOk()
        {
            Perfil perfil = new Perfil();
            bool resultado = perfil.ValidarPin("00000");
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilInvalidoExcepcion))]
        public void ValidarPinCortoPerfil()
        {
            Perfil perfil = new Perfil();
            bool resultado = perfil.ValidarPin("123");
            Assert.IsTrue(resultado);   
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilInvalidoExcepcion))]
        public void ValidarPinCaso0Perfil()
        {
            Perfil perfil = new Perfil();
            bool resultado = perfil.ValidarPin("0");
            Assert.IsTrue(resultado);
        }
        
        [TestMethod]
        [ExpectedException(typeof(PerfilInvalidoExcepcion))]
        public void ValidarPinLargoPerfil()
        {
            Perfil perfil = new Perfil();
            bool resultado = perfil.ValidarPin("123456");
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void CoincidePinPerfilOk()
        {
            Perfil perfil = new Perfil()
            {
                Pin = 12345
            };

            bool resultado = perfil.CoincidePin(12345);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void CoincidePinInvalidoPerfil()
        {
            Perfil perfil = new Perfil()
            {
                Pin = 12345
            };

            bool resultado = perfil.CoincidePin(12346);
            Assert.IsFalse(resultado);
        }
        
        [TestMethod]
        public void EsOwnerOk()
        {
            Perfil perfil = new Perfil()
            {
                Owner = true
            };

            Assert.IsTrue(perfil.Owner);
        }
        
        [TestMethod]
        public void EsInfantilOk()
        {
            Perfil perfil = new Perfil()
            {
                Infantil = true
            };

            Assert.IsTrue(perfil.Infantil);
        }
        
        [TestMethod]
        [ExpectedException(typeof(PerfilInvalidoExcepcion))]
        public void EsInfantilTest()
        {
            Perfil perfil = new Perfil()
            {
                Owner = true
            };
            perfil.Infantil = true;
        }
        
        [TestMethod]
        public void EstaLoggeadoOk()
        {
            Perfil perfil = new Perfil()
            {
                Logged = true
            };
            Assert.IsTrue(perfil.Logged);
        }
        
        [TestMethod]
        public void EstaLoggeadoTest()
        {
            Perfil perfil = new Perfil()
            {
                Logged = true
            };
            perfil.Logged = false;
            Assert.IsFalse(perfil.Logged);
        }
        
        [TestMethod]
        public void ToStringTest()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "unAlias",
            };
            Assert.IsTrue(perfil.ToString().Equals("unAlias"));
        }

        [TestMethod]
        public void EsOwnerYNoInfantilTest()
        {
            Perfil perfil = new Perfil()
            {
                Owner = true,
                Infantil = false
            };

            Assert.IsFalse(perfil.Infantil);
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilInvalidoExcepcion))]
        public void EsOwnerEInfantilTest()
        {
            Perfil perfil = new Perfil()
            {
                Owner = true,
                Infantil = true
            };
        }

        [TestMethod]
        public void EsInfantilNoOwnerTest()
        {
            Perfil perfil = new Perfil()
            {
                Owner = false,
                Infantil = true
            };
            Assert.IsTrue(perfil.Infantil && !perfil.Owner);
        }

        [TestMethod]
        public void AgregarGeneroOk()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "alias",
                Owner = false,
                Infantil = true
            };
            Genero unGenero = new Genero()
            {
                Nombre = "unNombre"
            };
            perfil.AgregarGenero(unGenero);
            Assert.IsTrue(perfil.Generos.Count == 1);
        }
        
        [TestMethod]
        public void ClonarGenerosOk()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "alias",
                Owner = false,
                Infantil = true
            };
            Genero unGenero = new Genero()
            {
                Nombre = "unNombre",
                Puntaje = 1
            };
            List<Genero> logicaGenero = new List<Genero>();
            logicaGenero.Add(unGenero);
            perfil.ClonarGeneros(logicaGenero);
            Assert.IsTrue(perfil.Generos.Count == 1 && perfil.Generos[0].Puntaje==0);
        }
        
        [TestMethod]
        public void ClonarPeliculasOk()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "alias",
                Owner = false,
                Infantil = true
            };
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unaPelicula",
                Puntaje = 1
            };
            List<Pelicula> logicaPelicula = new List<Pelicula>();
            logicaPelicula.Add(unaPelicula);
            perfil.ClonarPeliculas(logicaPelicula);
            Assert.IsTrue(perfil.Peliculas.Count == 1 && perfil.Peliculas[0].Puntaje==0);
        }

        [TestMethod]
        public void AgregarPeliculaOk()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "alias",
                Owner = false,
                Infantil = true
            };
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unNombre"
            };
            perfil.AgregarPelicula(unaPelicula);
            Assert.IsTrue(perfil.Peliculas.Count == 1);
        }
        
        [TestMethod]
        public void AgregarPeliculaClonadaOk()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "alias",
                Owner = false,
                Infantil = true
            };
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unNombre",
                Puntaje = 3
            };
            perfil.AgregarPeliculaClonada(unaPelicula);
            Assert.IsTrue(perfil.Peliculas.Count == 1 && perfil.Peliculas[0].Puntaje==0);
        }
        
        [TestMethod]
        public void AgregarGeneroClonadoOk()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "alias",
                Owner = false,
                Infantil = true
            };
            Genero unGenero = new Genero()
            {
                Nombre = "unNombre",
                Puntaje = 3
            };
            perfil.AgregarGeneroClonado(unGenero);
            Assert.IsTrue(perfil.Generos.Count == 1 && perfil.Generos[0].Puntaje==0);
        }

        [TestMethod]
        public void AgregarPeliculaVistaOk()
        {
            Perfil perfil = new Perfil()
            {
                Alias = "alias"
            };
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "unaPelicula"
            };
            perfil.AgregarPeliculaVista(unaPelicula);
            Assert.IsTrue(perfil.PeliculasVistas.Count == 1);
        }
    }
}
