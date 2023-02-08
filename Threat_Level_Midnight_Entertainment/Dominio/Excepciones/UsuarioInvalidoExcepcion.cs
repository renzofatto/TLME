using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class UsuarioInvalidoExcepcion : Exception
    {

        public UsuarioInvalidoExcepcion(string message) : base(message)
        {

        }
    }
}
