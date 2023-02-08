using System;

namespace LogicaNegocio
{
    public class LogicaNegocioPeliculaExcepcion: Exception
    {
        public LogicaNegocioPeliculaExcepcion(string message) : base(message)
        {

        }
    }
}