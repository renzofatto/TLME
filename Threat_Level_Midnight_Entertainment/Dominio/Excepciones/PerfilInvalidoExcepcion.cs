using System;

namespace Dominio
{
    public class PerfilInvalidoExcepcion : Exception
    {

        public PerfilInvalidoExcepcion(string message) : base(message)
        {

        }

    }
}