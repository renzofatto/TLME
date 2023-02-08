using LogicaNegocio;
using Dominio;
using System.Collections.Generic;

namespace RepositorioEnMemoria
{
    public class RepositorioUsuariosImpl : IRepositorioUsuarios
    {
        private List<Usuario> Usuarios { get; }

        public RepositorioUsuariosImpl()
        {
            Usuarios = new List<Usuario>();
        }

        public void Agregar(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return Usuarios;
        }
    }
}