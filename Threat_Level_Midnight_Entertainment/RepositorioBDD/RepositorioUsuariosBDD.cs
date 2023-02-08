using Dominio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioBDD
{
    public class RepositorioUsuariosBDD : IRepositorioUsuarios
    {
        public void Agregar(Usuario unUsuario)
        {
            using (var context = new TLMDBContext())
            {
                context.Usuarios.Add(unUsuario);
                context.SaveChanges();
            }
            
        }

        public List<Usuario> ObtenerUsuarios()
        {
            using (var context = new TLMDBContext())
            {
                return context.Usuarios.ToList();
            }
        }
    }
}
