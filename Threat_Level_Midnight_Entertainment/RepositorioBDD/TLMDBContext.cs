using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioBDD
{
    public class TLMDBContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Reparto> Repartos { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }

        public TLMDBContext() : base("TLMObl")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API
        }
    }
}
