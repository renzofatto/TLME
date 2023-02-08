using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DominioTest
{
    [TestClass]
    public class FuncionHashTest
    {
        [TestMethod]
        public void ValidarHashOk()
        {
            string contrasena = "unaContrasena";
            Assert.IsFalse(FuncionHash.Hash(contrasena).Equals(contrasena));
        }
    }
}
