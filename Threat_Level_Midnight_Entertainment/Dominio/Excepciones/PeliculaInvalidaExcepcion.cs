using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class PeliculaInvalidaExcepcion : Exception
    {
        public PeliculaInvalidaExcepcion(string message) : base(message)
        {

        }
    }
}
