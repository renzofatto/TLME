using System;

namespace Dominio.Excepciones
{
    public class GeneroInvalidoExcepcion : Exception
    {
        public GeneroInvalidoExcepcion(string message) : base(message)
        {

        }
    }
}