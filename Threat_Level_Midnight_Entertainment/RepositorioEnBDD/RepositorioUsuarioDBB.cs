using Dominio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Text;
using System.Threading.Tasks;
using RepositorioEnBDD;

namespace RepositorioEnBDD
{
    public class RepositorioUsuariosBDD : IRepositorioUsuarios
    {
        public void Agregar(Usuario unUsuario)
        {
            using (var context = new TLMDBContext())
            {
                foreach (Perfil perfil in unUsuario.Perfiles)
                {
                    context.Perfiles.Attach(perfil);
                }
                context.Usuarios.Add(unUsuario);
                context.SaveChanges();
            }

        }

        public void AgregarPerfil(Perfil unPerfil)
        {
            using (var context = new TLMDBContext())
            {
                foreach (Genero unGenero in unPerfil.Generos)
                {
                    context.Generos.Attach(unGenero);
                }

                foreach (Pelicula unaPelicula in unPerfil.Peliculas)
                {
                    context.Peliculas.Attach(unaPelicula);
                }

                foreach (Pelicula unaPelicula in unPerfil.PeliculasVistas)
                {
                    context.Peliculas.Attach(unaPelicula);
                }
                //context.Usuarios.Attach(unPerfil.Usuario);
                context.Perfiles.Add(unPerfil);
                context.SaveChanges();
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            using (var context = new TLMDBContext())
            {
                return context.Usuarios.Include(c => c.Perfiles).ToList();
            }
        }


    }
}