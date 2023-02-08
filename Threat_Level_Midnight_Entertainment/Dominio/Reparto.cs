using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Reparto
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Imagen { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{this.Nombre}";
        }
    }
}